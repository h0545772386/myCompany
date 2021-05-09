using System;
using System.Data.Entity.Migrations;
using System.Windows;

namespace myCompany
{
    /// <summary>
    /// Interaction logic for WorkersW.xaml
    /// </summary>
    public partial class ShiftW : Window
    {
        public Worker worker { get; set; }
        private Shift shift;

        public ShiftW(Shift shift = null)
        {
            InitializeComponent();
            if (shift != null)
            {
                this.shift = shift;
            }
            else
            {
                this.shift = new Shift();
                cbDeleted.Visibility = Visibility.Collapsed;
                tb_cbDeleted.Visibility = Visibility.Collapsed;
                dpDate1.SelectedDate = DateTime.Today;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Init1();
        }

        private void Init1()
        {
            if (shift.WHId == 0)
            {
                return;
            }

            var lw = this.Dispatcher.BeginInvoke(new Action(() =>
            {
                GetRecords();
            }));
        }

        private void GetRecords()
        {
            dpDate1.SelectedDate = shift.WHDate.INT2Date();
            tpIn.SetTime(shift.WHIn);
            tpOut.SetTime(shift.WHOut);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Activate();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            shift.WHDate = dpDate1.SelectedDate.Value.DateToINT_YYYYMMDD();
            shift.WHIn = tpIn.ToString();
            shift.WHOut = tpOut.ToString();
            shift.Status = (bool)cbDeleted.IsChecked ? "לא פעיל" : "פעיל";

            CalcFee();
            using (var db = new Model1())
            {
                if (shift.WHId != 0)
                {
                    db.Shifts.AddOrUpdate(shift);
                }

                if (shift.WHId == 0)
                {
                    db.Shifts.Add(shift);
                }

                db.SaveChanges();
            }

            this.Close();
            this.Owner.Activate();
            return;
        }

        private void CalcFee()
        {
            shift.WrkrNumber = worker.WrkrNumber;
            shift.IsHourly = worker.IsHourly;
            shift.IsGlobally = worker.IsGlobally;
            shift.GloballyTotal = worker.GloballyTotal;
            shift.HourlyPrice = worker.HourlyPrice;
            shift.TripPrice = worker.TripPrice;

            // בניית שעות משמרת
            DateTime d_in = shift.WHDate.INT2Date();
            DateTime d_out = d_in;
            string[] arr = shift.WHIn.Split(':');
            d_in = d_in.AddHours(Convert.ToInt32(arr[0])).AddMinutes(Convert.ToInt32(arr[1]));
            arr = shift.WHOut.Split(':');
            d_out = d_out.AddHours(Convert.ToInt32(arr[0])).AddMinutes(Convert.ToInt32(arr[1]));
            if (d_in > d_out)
            {
                d_out = d_out.AddDays(1);
                shift.WHOut = UTILS.ConvertOver24(shift.WHOut);
            }
            shift.WHTotalHours = Math.Round(Convert.ToDecimal((d_out - d_in).TotalHours), 2);

            if (shift.WHDate.INT2Date().DayOfWeek == DayOfWeek.Saturday)
            {
                shift.WH200 = shift.WHTotalHours;
            }
            else
            {
                if (shift.WHTotalHours <= 8)
                {
                    shift.WH100 = shift.WHTotalHours;
                }
                else
                {
                    decimal TotalHours = shift.WHTotalHours;
                    if (TotalHours > 8)
                    {
                        shift.WH100 = 8;
                        TotalHours -= 8;
                    }
                    if (TotalHours <= 2)
                    {
                        shift.WH125 = TotalHours;
                        TotalHours = 0;
                    }
                    else
                    {
                        shift.WH125 = 2;
                        TotalHours -= 2;
                    }
                    if (TotalHours > 0)
                    {
                        shift.WH150 = TotalHours;
                        TotalHours = 0;
                    }
                }
            }
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Activate();
            return;
        }
    }
}

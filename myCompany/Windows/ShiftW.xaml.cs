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

        public ShiftW(Shift shift)
        {
            InitializeComponent();
            this.shift = shift;
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
                db.Shifts.AddOrUpdate(shift);
                db.SaveChanges();
            }
            this.Close();
            this.Owner.Activate();
            return;
        }

        private void CalcFee()
        {
            //var w1 = worker;
            //shift.IsHourly = w1.IsHourly;
            //shift.IsGlobally = w1.IsGlobally;
            //shift.GloballyTotal = w1.GloballyTotal;
            //shift.HourlyPrice = w1.HourlyPrice;
            //shift.TripPrice = w1.TripPrice;

            //if (shift.IsHourly)
            //{
            //    // חישוב שכר שעות לפי חלוקה
            //    shift.DialyFeeTotal = Math.Round(
            //                         shift.WH100 * shift.HourlyPrice * (decimal)1.00 +
            //                         shift.WH125 * shift.HourlyPrice * (decimal)1.25 +
            //                         shift.WH150 * shift.HourlyPrice * (decimal)1.50 +
            //                         shift.WH200 * shift.HourlyPrice * (decimal)2.00 +
            //                         shift.TripPrice, 2);
            //}
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Activate();
            return;
        }
    }
}

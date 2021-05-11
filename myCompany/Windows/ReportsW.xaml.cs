using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace myCompany
{
    /// <summary>
    /// Interaction logic for WorkersW.xaml
    /// </summary>
    public partial class ReportsW : Window
    {
        private int FromDate;
        private int ToDate;
        private List<Shift> LSH;
        private List<ShiftSums> LSHS_D;
        private List<ShiftSums> LSHS_M;

        public ReportsW()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            SetMonthName();
            tbYear.Text = DateTime.Today.Year.ToString();
        }

        private void DoBackground()
        {
            DateTime d = new DateTime(Convert.ToInt32(tbYear.Text), Convert.ToInt32(SliderMonth.Value), 1);
            FromDate = d.DateToINT_YYYYMMDD();
            d = d.AddMonths(1).AddDays(-1);
            ToDate = d.DateToINT_YYYYMMDD();
            var lw = this.Dispatcher.BeginInvoke(new Action(() =>
            {
                GetRecords();
            }));
        }

        private void GetRecords()
        {
            List<Worker> LW = new List<Worker>();
            LSH = new List<Shift>();
            using (var db = new Model1())
            {
                LW = db.Workers.ToList();
                LSH = db.Shifts.Where(tt => tt.WHDate >= FromDate && tt.WHDate <= ToDate && tt.Status == "פעיל").ToList();
                LSH = LSH.OrderBy(tt => tt.WrkrNumber).ThenBy(tt => tt.WHDate).ToList();
                LSH.ForEach(tt => tt.WHMonth = tt.WHDate.GetMonthFromYYYYMMDD());
            }

            LSHS_D = new List<ShiftSums>();   // סיכום יומי
            LSHS_M = new List<ShiftSums>();   // סיכום חודשי

            LSHS_D = LSH.GroupBy(s => new { s.WrkrNumber, s.WHDate })
                        .Select(g => new ShiftSums
                        {
                            WrkrNumber = g.Key.WrkrNumber,
                            WHDate = g.Key.WHDate,
                            WH100Tot = g.Sum(x => Math.Round(Convert.ToDecimal(x.WH100), 2)),
                            WH125Tot = g.Sum(x => Math.Round(Convert.ToDecimal(x.WH125), 2)),
                            WH150Tot = g.Sum(x => Math.Round(Convert.ToDecimal(x.WH150), 2)),
                            WH200Tot = g.Sum(x => Math.Round(Convert.ToDecimal(x.WH200), 2)),
                            HourlyPrice = g.FirstOrDefault(x => x.WrkrNumber == g.Key.WrkrNumber).HourlyPrice,
                            TripPrice = g.FirstOrDefault(x => x.WrkrNumber == g.Key.WrkrNumber).TripPrice,
                        }).ToList();
            // הוספת שם עובד
            LSHS_D.ForEach(tt => tt.FullName = LW.FirstOrDefault(x => x.WrkrNumber == tt.WrkrNumber) != null ?
                                               LW.FirstOrDefault(x => x.WrkrNumber == tt.WrkrNumber).FullName : "");
            LSHS_D.ForEach(tt => tt.CalcDialyTotals());

            LSHS_M = LSH.GroupBy(s => new { s.WrkrNumber, s.WHMonth })
                        .Select(g => new ShiftSums
                        {
                            WrkrNumber = g.Key.WrkrNumber,
                            WHMonth = g.Key.WHMonth,
                            WH100Tot = g.Sum(x => Math.Round(Convert.ToDecimal(x.WH100), 2)),
                            WH125Tot = g.Sum(x => Math.Round(Convert.ToDecimal(x.WH125), 2)),
                            WH150Tot = g.Sum(x => Math.Round(Convert.ToDecimal(x.WH150), 2)),
                            WH200Tot = g.Sum(x => Math.Round(Convert.ToDecimal(x.WH200), 2)),
                        }).ToList();
            // הוספת שם עובד
            LSHS_M.ForEach(tt => tt.FullName = LW.FirstOrDefault(x => x.WrkrNumber == tt.WrkrNumber) != null ?
                                               LW.FirstOrDefault(x => x.WrkrNumber == tt.WrkrNumber).FullName : "");

            GBMonthly.Header = LSHS_M.Count.ToString();
            DGMonthly.ItemsSource = LSHS_M;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Activate();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (tbMonth == null)
            {
                return;
            }
            SetMonthName();
        }

        private void SetMonthName()
        {

            switch (Convert.ToInt32(SliderMonth.Value))
            {
                case 1:
                    tbMonth.Text = "ינואר";
                    break;
                case 2:
                    tbMonth.Text = "פברואר";
                    break;
                case 3:
                    tbMonth.Text = "מרץ";
                    break;
                case 4:
                    tbMonth.Text = "אפריל";
                    break;
                case 5:
                    tbMonth.Text = "מאי";
                    break;
                case 6:
                    tbMonth.Text = "יוני";
                    break;
                case 7:
                    tbMonth.Text = "יולי";
                    break;
                case 8:
                    tbMonth.Text = "אוגוסט";
                    break;
                case 9:
                    tbMonth.Text = "ספטמבר";
                    break;
                case 10:
                    tbMonth.Text = "אוקטובר";
                    break;
                case 11:
                    tbMonth.Text = "נובמבר";
                    break;
                case 12:
                    tbMonth.Text = "דצמבר";
                    break;
            }
        }

        private void TbYear_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            UTILS.Integer_PreviewTextInput(sender, e);
        }

        private void BIssueReport_Click(object sender, RoutedEventArgs e)
        {
            if (tbYear.Text.Length == 0)
            {
                MessageBox.Show("שגיאה !!", "נא להכניס שנה, חובה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int year = Convert.ToInt32(tbYear.Text);
            DoBackground();
        }

        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ShiftSums ss = null;
            if (DGMonthly.SelectedItem != null)
            {
                ss = DGMonthly.SelectedItem as ShiftSums;
            }

            if (ss == null)  // לא נבחר עובד מטבלה חודשית
            {
                return;
            }
            if (sender is TabControl)
            {
                TabControl tbc = sender as TabControl;
                if (((TabItem)tbc.SelectedItem).Name == "TIDialy")
                {
                    var LD = LSH.Where(tt => tt.WrkrNumber == ss.WrkrNumber).ToList();
                    if (LD != null)
                    {
                        var lshw = new List<ShiftView>();
                        foreach (Shift item in LD)
                        {
                            lshw.Add(item.Convert2ShiftView());
                        }
                        GBDialy.Header = lshw.Count.ToString();
                        DGDialy.ItemsSource = lshw;
                    }
                }
            }
        }
    }
}

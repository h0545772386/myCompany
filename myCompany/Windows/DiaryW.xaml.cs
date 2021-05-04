using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace myCompany
{
    /// <summary>
    /// Interaction logic for WorkersW.xaml
    /// </summary>
    public partial class DiaryW : Window
    {
        private List<Worker> LWS;
        private List<ShiftView> LSHV;
        public DiaryW()
        {
            InitializeComponent();
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
            using (var db = new Model1())
            {
                LWS = db.Workers.ToList();
            }
        }

        private void AddNewDepr_Click(object sender, RoutedEventArgs e)
        {
            DepartmentW dw = new DepartmentW();
            dw.Owner = this;
            dw.ShowDialog();
            Init1();
            Thread.Sleep(164);
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }

        private void cbAll_Checked(object sender, RoutedEventArgs e)
        {
            LoadFile();
        }

        private void cbAll_Unchecked(object sender, RoutedEventArgs e)
        {
            LoadFile();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = tbSearch.Text;
            ICollectionView icv = CollectionViewSource.GetDefaultView(DGShiftsView.ItemsSource);
            if (icv == null)
            {
                return;
            }

            if (filter == "")
            {
                icv.Filter = null;
            }
            else
            {
                icv.Filter = depr =>
                {
                    ShiftView d = depr as ShiftView;
                    return ((d.FullName.ToLower().Contains(filter.ToLower()) ||
                            (d.WrkrNumber.ToString().Contains(filter))
                            ));
                };
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Activate();
        }

        private void BBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                tbFullPath.Text = openFileDialog.FileName;
                LoadFile();
            }
        }

        private void LoadFile()
        {
            LSHV = new List<ShiftView>();
            var LSH = LoadShifts.LoadShiftsFromFile(tbFullPath.Text);
            foreach (var item in LSH)
            {
                LSHV.Add(item.Convert2ShiftView());
            }

            foreach (var item in LSHV)
            {
                var w1 = LWS.FirstOrDefault(tt => tt.WrkrNumber == item.WrkrNumber);
                if (w1 != null)
                {
                    item.FullName = w1.FullName;
                    item.IsHourly = w1.IsHourly;
                    item.IsGlobally = w1.IsGlobally;
                    item.GloballyTotal = w1.GloballyTotal;
                    item.HourlyPrice = w1.HourlyPrice;
                    item.TripPrice = w1.TripPrice;

                    if (item.IsHourly)
                    {
                        item.DialyFeeTotal = Math.Round(
                                             item.WH100 * item.HourlyPrice * (decimal)1.00 +
                                             item.WH125 * item.HourlyPrice * (decimal)1.25 +
                                             item.WH150 * item.HourlyPrice * (decimal)1.50 +
                                             item.WH200 * item.HourlyPrice * (decimal)2.00 +
                                             item.TripPrice, 2);
                    }
                    if (w1.Status != "Active")
                    {
                        item.Error = "NotActive";
                    }
                }
                else
                {
                    item.Error = "NotFound";
                }
            }
            LSHV = LSHV.OrderBy(tt => tt.WrkrNumber).ThenBy(tt => tt.WHDate).ToList();

            if (!(bool)cbAll.IsChecked)
            {
                LSHV = LSHV.Where(tt => tt.Error == "").ToList();
            }

            GBShiftsView.Header = LSHV.Count.ToString();
            DGShiftsView.ItemsSource = LSHV;

        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            List<Shift> LSH = new List<Shift>();

            foreach (var item in LSHV)
            {
                LSH.Add(item.Convert2Shift());
            }

            using (var db = new Model1())
            {
                var save_shifts = db.Shifts.ToList().Where(x => LSH.Any(y => y.WHDate == x.WHDate)).ToList();  // שליפת רשומות קיימות לפי תאריך
                foreach (var item in LSH)
                {
                    var sh = save_shifts.FirstOrDefault(tt => tt.WrkrNumber == item.WrkrNumber && // בדיקה אם קיימת רשומה כבר עם הנתונים
                                                              tt.WHDate == item.WHDate &&
                                                              tt.WHIn == item.WHIn &&
                                                              tt.WHOut == item.WHOut &&
                                                              tt.Status == "פעיל");
                    if (sh == null)
                        db.Shifts.Add(item);
                }

                db.SaveChanges();
                bSave.IsEnabled = false;
            }
            this.Close();
        }

        private void DGShiftsView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //ShiftView dep = null;
            //if (DGShiftsView.SelectedItem != null)
            //{
            //    dep = DGShiftsView.SelectedItem as ShiftView;
            //}

            //if (dep == null)
            //{
            //    return;
            //}

            //dep.VS = ViewState.Edit;
            //DepartmentW dw = new DepartmentW(dep);
            //dw.Owner = this;
            //dw.ShowDialog();
            //Init1();
            //Thread.Sleep(164);
        }
    }
}

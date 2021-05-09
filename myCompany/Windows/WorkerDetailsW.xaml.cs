using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace myCompany
{
    /// <summary>
    /// Interaction logic for WorkersW.xaml
    /// </summary>
    public partial class WorkerDetailsW : Window
    {
        private Worker worker;
        private List<Shift> LSH;
        private List<ShiftView> LSHV;

        public WorkerDetailsW(Worker worker)
        {
            InitializeComponent();
            this.worker = worker;
            this.DataContext = worker;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            dpDate1.SelectedDate = DateTime.Today.AddDays(1 + DateTime.Today.Day * -1);
            dpDate2.SelectedDate = dpDate1.SelectedDate.Value.AddMonths(1).AddDays(-1);
            Init1();
        }

        private void Init1()
        {
            var a1 = this.Dispatcher.BeginInvoke(new Action(() =>
            {
                GetRecords();
            }));
        }

        private void GetRecords()
        {
            var date_from = dpDate1.SelectedDate.Value.DateToINT_YYYYMMDD();
            var date_to = dpDate2.SelectedDate.Value.DateToINT_YYYYMMDD();
            LSHV = new List<ShiftView>();
            using (var db = new Model1())
            {
                LSH = db.Shifts.Where(tt => tt.WrkrNumber == worker.WrkrNumber && tt.WHDate >= date_from && tt.WHDate <= date_to && tt.Status == "פעיל").ToList();
            }

            foreach (var item in LSH)
            {
                LSHV.Add(item.Convert2ShiftView());
            }

            GBShiftsView.Header = LSHV.Count.ToString();
            DGShiftsView.ItemsSource = LSHV;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Activate();
            }
        }

        private void dpDate1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Init1();
        }

        private void dpDate2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Init1();
        }

        private void DGShiftsView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShiftView shv = null;
            if (DGShiftsView.SelectedItem != null)
            {
                shv = DGShiftsView.SelectedItem as ShiftView;
            }

            if (shv == null)
            {
                return;
            }

            var sh = shv.Convert2Shift();

            ShiftW sw = new ShiftW(sh);
            sw.worker = worker;
            sw.Owner = this;
            sw.ShowDialog();
            Init1();
            Thread.Sleep(164);
        }

        private void BAddShift_Click(object sender, RoutedEventArgs e)
        {
            ShiftW sw = new ShiftW();
            sw.worker = worker;
            sw.Owner = this;
            sw.ShowDialog();

            Init1();
            Thread.Sleep(164);
        }
    }
}

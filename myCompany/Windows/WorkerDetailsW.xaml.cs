using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace myCompany
{
    /// <summary>
    /// Interaction logic for WorkersW.xaml
    /// </summary>
    public partial class WorkerDetailsW : Window
    {
        Worker worker;
        List<Shift> LSH;
        List<ShiftView> LSHV;

        public WorkerDetailsW(Worker worker)
        {
            InitializeComponent();
            this.worker = worker;
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
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                GetRecords();
            }));
        }

        private void GetRecords()
        {
            var date_from = dpDate1.SelectedDate.Value.DateToINT_YYYYMMDD();
            var date_to = dpDate2.SelectedDate.Value.DateToINT_YYYYMMDD();
            using (var db = new Model1())
            {
                LSH = db.Shifts.Where(tt => tt.WrkrNumber == worker.WrkrNumber && tt.WHDate >= date_from && tt.WHDate <= date_to && tt.Status == "פעיל").ToList();
            }
            Inint1();
            this.DataContext = worker;
        }

        private void Inint1()
        {
            foreach (var item in LSH)
            {
                LSHV.Add(item.Convert2ShiftView());
            }

            GBShiftsView.Header = LSHV.Count.ToString();
            DGShiftsView.ItemsSource = LSHV;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Activate();
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

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    public partial class WorkersW : Window
    {
        List<Worker> LW;
        public WorkersW()
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
                if (GlobalsVars.LoggedWorker.IsSysAdmin)
                {
                    if (cbAll.IsChecked != true)
                        LW = db.Workers.Where(tt => tt.Status == "Active").ToList();
                    else
                        LW = db.Workers.ToList();
                }
                else
                {
                    if (cbAll.IsChecked != true)
                        LW = db.Workers.Where(tt => tt.Status == "Active" && tt.ManagerId == GlobalsVars.LoggedWorker.WrkrNumber).ToList();
                    else
                        LW = db.Workers.Where(tt => tt.ManagerId == GlobalsVars.LoggedWorker.WrkrNumber).ToList();
                }
                GBWorkers.Header = LW.Count.ToString();
                DGWorkers.ItemsSource = LW;
            }
        }

        private void AddNewWorker_Click(object sender, RoutedEventArgs e)
        {
            WorkerW ww = new WorkerW();
            ww.Owner = this;
            ww.ShowDialog();
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
            Init1();
        }

        private void cbAll_Unchecked(object sender, RoutedEventArgs e)
        {
            Init1();
        }

        private void DGWorkers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void OnHyperlinkClick(object sender, RoutedEventArgs e)
        {
            Worker worker = null;
            if (DGWorkers.SelectedItem != null)
            {
                worker = DGWorkers.SelectedItem as Worker;
            }

            if (worker == null)
            {
                return;
            }
            worker.VS = ViewState.Edit;
            WorkerW ww = new WorkerW(worker);
            ww.Owner = this;
            ww.ShowDialog();
            Init1();
            Thread.Sleep(164);
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = tbSearch.Text;
            ICollectionView icv = CollectionViewSource.GetDefaultView(DGWorkers.ItemsSource);

            if (filter == "")
            {
                icv.Filter = null;
            }
            else
            {
                icv.Filter = wrkr =>
                {
                    Worker w = wrkr as Worker;
                    return ((w.FullName.ToLower().Contains(filter.ToLower()) ||
                            //(w.WrkrDepartment.ToLower().Contains(filter.ToLower())) ||
                            //(w.WrkrRole.ToLower().Contains(filter.ToLower())) ||
                            (w.Phone1.ToLower().Contains(filter.ToLower())) ||
                            (w.Phone2.ToLower().Contains(filter.ToLower())) ||
                            (w.WrkrNumber.ToString().Contains(filter)) ||
                            (w.ManagerId.ToString().Contains(filter))
                            ));
                };
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Activate();
        }
    }
}

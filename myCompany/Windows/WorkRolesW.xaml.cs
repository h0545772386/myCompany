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
    public partial class WorkRolesW : Window
    {
        private List<WorkRole> WR;
        public WorkRolesW()
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
                if (cbAll.IsChecked != true)
                {
                    WR = db.WorkRoles.Where(tt => tt.Status == "Active").ToList();
                }
                else
                {
                    WR = db.WorkRoles.ToList();
                }

                GBWrkRols.Header = WR.Count.ToString();
                DGWrkRols.ItemsSource = WR;
            }
        }

        private void AddNewRole_Click(object sender, RoutedEventArgs e)
        {
            WorkRoleW ww = new WorkRoleW();
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

        private void DGWrkRols_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void OnHyperlinkClick(object sender, RoutedEventArgs e)
        {
            WorkRole wr = null;
            if (DGWrkRols.SelectedItem != null)
            {
                wr = DGWrkRols.SelectedItem as WorkRole;
            }

            if (wr == null)
            {
                return;
            }
            wr.VS = ViewState.Edit;
            WorkRoleW wrw = new WorkRoleW(wr);
            wrw.Owner = this;
            wrw.ShowDialog();
            Init1();
            Thread.Sleep(164);
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = tbSearch.Text;
            ICollectionView icv = CollectionViewSource.GetDefaultView(DGWrkRols.ItemsSource);

            if (filter == "")
            {
                icv.Filter = null;
            }
            else
            {
                icv.Filter = wrkr =>
                {
                    WorkRole w = wrkr as WorkRole;
                    return ((w.RoleName.ToLower().Contains(filter.ToLower()) ||
                            (w.RolId.ToString().Contains(filter))
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

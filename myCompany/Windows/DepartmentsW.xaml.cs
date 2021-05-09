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
    public partial class DepartmentsW : Window
    {
        private List<Department> LD;
        public DepartmentsW()
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
                    LD = db.Departments.Where(tt => tt.Status == "Active").ToList();
                }
                else
                {
                    LD = db.Departments.ToList();
                }
            }
            GBDepers.Header = LD.Count.ToString();
            DGDepers.ItemsSource = LD;
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
            Init1();
        }

        private void cbAll_Unchecked(object sender, RoutedEventArgs e)
        {
            Init1();
        }

        private void DGDepers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Department dep = null;
            if (DGDepers.SelectedItem != null)
            {
                dep = DGDepers.SelectedItem as Department;
            }

            if (dep == null)
            {
                return;
            }

            DepartmentW dw = new DepartmentW(dep);
            dw.Owner = this;
            dw.ShowDialog();
            Init1();
            Thread.Sleep(164);
        }
        private void OnHyperlinkClick(object sender, RoutedEventArgs e)
        {
            Department dep = null;
            if (DGDepers.SelectedItem != null)
            {
                dep = DGDepers.SelectedItem as Department;
            }

            if (dep == null)
            {
                return;
            }

            DepartmentW dw = new DepartmentW(dep);
            dw.Owner = this;
            dw.ShowDialog();
            Init1();
            Thread.Sleep(164);
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = tbSearch.Text;
            ICollectionView icv = CollectionViewSource.GetDefaultView(DGDepers.ItemsSource);

            if (filter == "")
            {
                icv.Filter = null;
            }
            else
            {
                icv.Filter = depr =>
                {
                    Department d = depr as Department;
                    return ((d.DeprName.ToLower().Contains(filter.ToLower()) ||
                            (d.DeprId.ToString().Contains(filter))
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

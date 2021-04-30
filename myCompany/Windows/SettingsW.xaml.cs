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
    public partial class SettingsW : Window
    {

        public SettingsW()
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
                //LW = db.Workers.Where(tt => tt.Status != "Deleted").ToList();
                Thread.Sleep(5000);
                // DGWorkers.ItemsSource = LW;
                // GBWorkers.ItemsSource = LW.Count;  
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Activate();
        }

        private void bDepartments_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bWorkRoles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

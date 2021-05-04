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

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Activate();
        }

        private void bDepartments_Click(object sender, RoutedEventArgs e)
        {
            DepartmentsW dw = new DepartmentsW();
            dw.Owner = this;
            dw.ShowDialog();
        }

        private void bWorkRoles_Click(object sender, RoutedEventArgs e)
        {
            WorkRolesW ww = new WorkRolesW();
            ww.Owner = this;
            ww.ShowDialog();
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Activate();
            return;
        }
    }
}

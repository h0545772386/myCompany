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
        List<WorkRole> LRols;      // רשימת תפקידים
        List<Worker> LManagers;    // רשימת מנהלים
        List<Department> LDeprs;   // רשימת מחלקות
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
            using (var db = new Model1())
            {
                LRols = db.WorkRoles.Where(tt => tt.Status == "Active").ToList();
                LDeprs = db.Departments.Where(tt => tt.Status == "Active").ToList();
                LManagers = db.Workers.Where(tt => tt.IsManager && tt.Status == "Active").ToList();
            }

            Inint1();

            this.DataContext = worker;
        }

        private void Inint1()
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Activate();
        }
    }
}

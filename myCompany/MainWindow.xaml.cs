using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace myCompany
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // פץח חלון כניסה למערכת
            LoginW lgnw = new LoginW();
            lgnw.ShowDialog();

            if (GlobalsVars.LoggedWorker == null)
                Application.Current.Shutdown();   // סוגרים את כל האפליקציה בגלל שלא הצליח להיכנס עם שם משתמש וסיסמה 
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            tbVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void bWorkers_Click(object sender, RoutedEventArgs e)
        {
            WorkersW wrkrsw = new WorkersW();
            wrkrsw.Owner = this;
            wrkrsw.ShowDialog();
        }

        private void bDiary_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bTimeTable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bReports_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bSetting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

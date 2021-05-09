using System;
using System.Windows;

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
            // פתח חלון כניסה למערכת
            LoginW lgnw = new LoginW();
            lgnw.ShowDialog();

            if (App.LoggedWorker == null)
            {
                Application.Current.Shutdown();   // סוגרים את כל האפליקציה בגלל שלא הצליח להיכנס עם שם משתמש וסיסמה 
                return;
            }

            if (!App.LoggedWorker.IsManager)
            {
                WorkerDetailsW wdw = new WorkerDetailsW(App.LoggedWorker);
                wdw.ShowDialog();
                Application.Current.Shutdown();   // סוגרים את כל האפליקציה בגלל שלא הצליח להיכנס עם שם משתמש וסיסמה 
            }
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
            DiaryW dryw = new DiaryW();
            dryw.Owner = this;
            dryw.ShowDialog();
        }

        private void bTimeTable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bReports_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bSetting_Click(object sender, RoutedEventArgs e)
        {
            SettingsW sw = new SettingsW();
            sw.Owner = this;
            sw.ShowDialog();
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            return;
        }
    }
}

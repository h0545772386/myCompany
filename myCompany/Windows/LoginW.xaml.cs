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
    public partial class LoginW : Window
    {
        public LoginW()
        {
            InitializeComponent();
            GlobalsVars.LoggedWorker = null;
            if(Environment.MachineName == "ASUS-X509J" || Environment.MachineName == "PC164")
            {
                txUser.Text = "FN1";
                txPassWord.Password = "fn1";
            }
        }

        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            Worker w = null;
            using (var db = new Model1())
            {
                w = db.Workers.FirstOrDefault(tt => tt.UserName.ToLower() == txUser.Text.Trim().ToLower() && tt.UserPass == txPassWord.Password.Trim());
            }
            if (w != null)
            {
                GlobalsVars.LoggedWorker = w;
                this.Close();
                return;
            }
            txErrMsg.Text = "שם או סיסמה לא נכונים";
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }

        private void txUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            txErrMsg.Text = "";
        }

        private void txPassWord_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txErrMsg.Text = "";
        }
    }
}

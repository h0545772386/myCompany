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
    public partial class DerprmntW : Window
    {
        Worker worker;
        List<WorkRole> LRols;      // רשימת תפקידים
        List<Worker> LManagers;    // רשימת מנהלים
        List<Department> LDeprs;   // רשימת מחלקות
        public DerprmntW(Worker worker = null)
        {
            InitializeComponent();
            if (worker != null)
            {
                this.worker = worker;
                Translate("ToHeb");
            }
            else
            {
                this.worker = new Worker();
                this.worker.VS = ViewState.New;
                cboStatus.SelectedValue = "פעיל";
            }
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
            cboWrkrRole.ItemsSource = LRols;
            cboWrkrDepartment.ItemsSource = LDeprs;
            cboManagerFullName.ItemsSource = LManagers;
            if (worker.VS == ViewState.New)
            {
                cbIsHourly.IsChecked = true;
            }
            else if (worker.VS == ViewState.Edit)
            {
                tbUserPass.Password = tbUserPass1.Password = worker.UserPass;
                tbWrkrNumber.IsReadOnly = true;
                bNextNumber.Visibility = Visibility.Collapsed;
            }

        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Translate("ToEng");

            if (FoundValidatingError())
                return;
            if (worker.VS == ViewState.New)
                CreateNew();
            else if (worker.VS == ViewState.Edit)
                UPdateExist();
        }

        private bool FoundValidatingError()
        {
            bool result = false;  // הכול תקין
            if (tbWrkrNumber.Text.Trim() == "")
            {
                MessageBox.Show("שגיאה !!", "מספר עובד ריק, חובה להכניס", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (worker.VS == ViewState.New)
                if (DB_Provider.WorkerNumberAlreadyExist(worker.WrkrNumber))
                {
                    MessageBox.Show("שגיאה !!", "מספר עובד קיים במערכת", MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }
            if (!UTILS.Is_Valid_IDN(tbIDN.Text))
            {
                MessageBox.Show("שגיאה !!", "מספר תעודת הזהות לא תקין", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (tbFullName.Text.Trim() == "")
            {
                MessageBox.Show("שגיאה !!", "שם עובד ריק, חובה להכניס", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (tbUserName.Text.Trim() == "")
            {
                MessageBox.Show("שגיאה !!", "שם משתמש ריק, חובה להכניס", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (!Regex.IsMatch(tbUserName.Text.Trim(), "^[a-zA-Z0-9()./]*$"))
            {
                MessageBox.Show("שגיאה !!", "שם משתמש אנגלית או ספרות, חובה", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (tbUserPass.Password.Trim() == "" || tbUserPass1.Password.Trim() == "")
            {
                MessageBox.Show("שגיאה !!", "חובה להכניס סיסמאות", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }

            worker.UserPass = tbUserPass.Password.Trim();
            if (tbUserPass.Password.Trim() != tbUserPass1.Password.Trim())
            {
                MessageBox.Show("שגיאה !!", "חובה להכניס סיסמאות זהות", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (tbPhopne1.Text.Trim() == "")
            {
                MessageBox.Show("שגיאה !!", " מספר טלפון ריק, חובה להכניס", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (worker.WrkrNumber == 0)
                worker.WrkrNumber = DB_Provider.GetNextWorkerNumber();













            return result;
        }

        private void CreateNew()
        {
            using (var db = new Model1())
            {
                db.Workers.Add(worker);
                db.SaveChanges();
            }
        }

        private void UPdateExist()
        {
            using (var db = new Model1())
            {
                db.Workers.AddOrUpdate(worker);
                db.SaveChanges();
            }
        }

        private void bNextNumber_Click(object sender, RoutedEventArgs e)
        {
            worker.WrkrNumber = DB_Provider.GetNextWorkerNumber();
            tbWrkrNumber.Text = worker.WrkrNumber.ToString();
        }

        private void tbWrkrNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            UTILS.Integer_PreviewTextInput(sender, e);
        }

        private void tbIDN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            UTILS.Integer_PreviewTextInput(sender, e);
        }

        private void tbIDN_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!UTILS.Is_Valid_IDN(tbIDN.Text.Trim()))
            {
                tbIDN.Foreground = System.Windows.Media.Brushes.Red;
            }
            else
            {
                tbIDN.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void tbHourlyPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            UTILS.Decimal_PreviewTextInput(sender, e);
        }

        private void tbTripPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            UTILS.Decimal_PreviewTextInput(sender, e);
        }

        private void tbGloballyTotal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            UTILS.Decimal_PreviewTextInput(sender, e);
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Activate();
        }

        private void tbBankNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            UTILS.Integer_PreviewTextInput(sender, e);
        }

        private void tbBnkBrnchNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            UTILS.Integer_PreviewTextInput(sender, e);
        }

        private void tbBnkAccountNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            UTILS.Integer_PreviewTextInput(sender, e);
        }

        private void Translate(string ToLang)
        {
            if (ToLang == "ToEng")
            {
                // שינוי ערכים לאנגלית לפני שמירה
                if (worker.Status == "פעיל")
                    worker.Status = "Active";
                else
                    worker.Status = "InActive";
                if (worker.Gender == "זכר")
                    worker.Gender = "Male";
                else if (worker.Gender == "נקבה")
                    worker.Gender = "FMale";
                else if (worker.Gender == "אחר")
                    worker.Gender = "Other";
            }
            else if (ToLang == "ToHeb")
            {
                // שינוי ערכים לעברית לפני הצגה למסך
                if (worker.Status == "Active")
                    worker.Status = "פעיל";
                else
                    worker.Status = "לא פעיל";


                if (worker.Gender == "Male")
                    worker.Gender = "זכר";
                else if (worker.Gender == "FMale")
                    worker.Gender = "נקבה";
                else if (worker.Gender == "Other")
                    worker.Gender = "אחר";
            }
        }

        private void cbIsHourly_Checked(object sender, RoutedEventArgs e)
        {
            cbIsGlobally.IsChecked = false;
        }

        private void cbIsHourly_Unchecked(object sender, RoutedEventArgs e)
        {
            cbIsGlobally.IsChecked = true;
        }

        private void cbIsGlobally_Checked(object sender, RoutedEventArgs e)
        {
            cbIsHourly.IsChecked = false;
        }

        private void cbIsGlobally_Unchecked(object sender, RoutedEventArgs e)
        {
            cbIsHourly.IsChecked = true;
        }
    }
}

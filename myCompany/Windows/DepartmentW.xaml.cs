using System;
using System.Data.Entity.Migrations;
using System.Windows;

namespace myCompany
{
    /// <summary>
    /// Interaction logic for WorkersW.xaml
    /// </summary>
    public partial class DepartmentW : Window
    {
        private Department department;   // רשימת מחלקות
        public DepartmentW(Department department = null)
        {
            InitializeComponent();
            if (department != null)
            {
                this.department = department;
                Translate("ToHeb");
            }
            else
            {
                this.department = new Department();
                cboStatus.SelectedValue = "פעיל";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {

        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Translate("ToEng");

            if (FoundValidatingError())
            {
                return;
            }

            if (department.DeprId == 0)
            {
                CreateNew();
            }
            else if (department.DeprId != 0)
            {
                UPdateExist();
            }
        }

        private bool FoundValidatingError()
        {
            bool result = false;  // הכול תקין
            if (tbDeprName.Text.Trim() == "")
            {
                MessageBox.Show("שגיאה !!", "שם מחלקה ריק, חובה להכניס", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            return result;
        }

        private void CreateNew()
        {
            using (var db = new Model1())
            {
                db.Departments.Add(department);
                db.SaveChanges();
            }
        }

        private void UPdateExist()
        {
            using (var db = new Model1())
            {
                db.Departments.AddOrUpdate(department);
                db.SaveChanges();
            }
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

        private void Translate(string ToLang)
        {
            if (ToLang == "ToEng")
            {
                // שינוי ערכים לאנגלית לפני שמירה
                if (department.Status == "פעיל")
                    department.Status = "Active";
                else
                    department.Status = "InActive";
            }
            else if (ToLang == "ToHeb")
            {
                // שינוי ערכים לעברית לפני הצגה למסך
                if (department.Status == "Active")
                    department.Status = "פעיל";
                else
                    department.Status = "לא פעיל";
            }
        }
    }
}

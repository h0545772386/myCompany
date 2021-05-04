using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;

namespace myCompany
{
    /// <summary>
    /// Interaction logic for WorkersW.xaml
    /// </summary>
    public partial class WorkRoleW : Window
    {
        private WorkRole Work_role;

        public WorkRoleW(WorkRole Work_role = null)
        {
            InitializeComponent();
            if (Work_role != null)
            {
                this.Work_role = Work_role;
                Translate("ToHeb");
            }
            else
            {
                this.Work_role = new WorkRole();
                this.Work_role.VS = ViewState.New;
                cboStatus.SelectedValue = "פעיל";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            this.DataContext = Work_role;
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Translate("ToEng");

            if (FoundValidatingError())
            {
                return;
            }

            if (Work_role.VS == ViewState.New)
            {
                CreateNew();
            }
            else if (Work_role.VS == ViewState.Edit)
            {
                UPdateExist();
            }
        }

        private bool FoundValidatingError()
        {
            bool result = false;  // הכול תקין
            if (tbRoleName.Text.Trim() == "")
            {
                MessageBox.Show("שגיאה !!", "תפקיד ריק, חובה להכניס", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }


            return result;
        }

        private void CreateNew()
        {
            using (var db = new Model1())
            {
                db.WorkRoles.Add(Work_role);
                db.SaveChanges();
            }
        }

        private void UPdateExist()
        {
            using (var db = new Model1())
            {
                db.WorkRoles.AddOrUpdate(Work_role);
                db.SaveChanges();
            }
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Activate();
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
                if (Work_role.Status == "פעיל")
                {
                    Work_role.Status = "Active";
                }
                else
                {
                    Work_role.Status = "InActive";
                }
            }
            else if (ToLang == "ToHeb")
            {
                // שינוי ערכים לעברית לפני הצגה למסך
                if (Work_role.Status == "Active")
                {
                    Work_role.Status = "פעיל";
                }
                else
                {
                    Work_role.Status = "לא פעיל";
                }
            }
        }
    }
}

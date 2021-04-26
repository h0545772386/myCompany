using System.Windows;

namespace myCompany
{
    public enum ViewState
    {
        View = 1,
        Edit = 2,
        New = 3
    }

    public class GlobalsVars
    {
        // משתנים גלובליים לכל הפרויקט
        public static Window OwnerW { get; set; }
        public static Worker LoggedWorker { get; set; }

        // משתנים גלובליים לכל הפרויקט
    }

}
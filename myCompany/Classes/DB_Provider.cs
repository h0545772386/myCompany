using System.Linq;

namespace myCompany
{
    // מחלקה לטיפול מול בסיס הנתונים
    public class DB_Provider
    {
        //מביא את מספר העובד הפנוי הבא בעת יצירת עובד חדש
        // כדי למנוע יצירת עובד עם אותו מספר
        public static int GetNextWorkerNumber()
        {
            int wn = 0;
            using (var db = new Model1())
            {
                wn = db.Workers.Max(x => x.WrkrNumber);
            }
            if (wn != 0)
            {
                return wn + 10;
            }
            else
            {
                return 100500;
            }
        }

        // פונקיצה שבודקת אם מספר העובד כבר קיים בבסיס הנתונים או לא
        // אם קיים מספר עובד אז הפונקציה מחזירה TRUE
        public static bool WorkerNumberAlreadyExist(int WorkerNumber)
        {
            Worker w = null;
            using (var db = new Model1())
            {
                w = db.Workers.FirstOrDefault(x => x.WrkrNumber == WorkerNumber);
            }
            if (w != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCompany
{
    public class DB_Provider
    {
        public static int GetNextWorkerNumber()
        {
            int wn = 0;
            using (var db = new Model1())
            {
                wn = db.Workers.Max(x => x.WrkrNumber);
            }
            if (wn != 0)
                return wn + 10;
            else
                return 100500;
        }
        public static bool WorkerNumberAlreadyExist(int WorkerNumber)
        {
            Worker w = null;
            using (var db = new Model1())
            {
                w = db.Workers.FirstOrDefault(x => x.WrkrNumber == WorkerNumber);
            }
            if (w != null)
                return true;
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCompany
{
    public class LoadShifts
    {
        public LoadShifts()
        {

        }


        public static List<Shift> LoadShiftsFromFile(string FilePath)
        {
            List<string> allLinesText = File.ReadAllLines(FilePath).ToList();

            return null;
        }
    }
}

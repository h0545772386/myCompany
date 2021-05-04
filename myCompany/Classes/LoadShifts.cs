using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace myCompany
{
    public class LoadShifts
    {
        public LoadShifts()
        {

        }

        public static List<TableCSV> LoadCSVFromFile(string FilePath)
        {
            List<TableCSV> TC = File.ReadAllLines(FilePath)
                                          .Skip(1)
                                          .Select(v => TableCSV.FromCsv(v))
                                          .ToList();
            return TC;
        }

        public static List<Shift> LoadShiftsFromFile(string FilePath)
        {
            List<Shift> LS = File.ReadAllLines(FilePath)
                                          .Skip(1)
                                          .Select(v => TableCSV.FromCsv2Shifts(v))
                                          .ToList();
            return LS;
        }
    }
}

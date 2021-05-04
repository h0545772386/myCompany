namespace myCompany
{
    using System;

    public class TableCSV
    {

        public int WorkerNumber { get; set; }
        public DateTime Date1 { get; set; }
        public string IN { get; set; }
        public string OUT { get; set; }
        public string Error { get; set; }

        public static Shift FromCsv2Shifts(string csvLine)
        {
            Shift sh = new Shift();
            TableCSV tc = new TableCSV();
            // המרה של שורה המקובץ למבנה
            string[] values = csvLine.Split(',');
            tc.WorkerNumber = Convert.ToInt32(values[0]);
            tc.Date1 = Convert.ToDateTime(values[1]);
            tc.IN = values[2];
            tc.OUT = values[3];

            // בניית שעות משמרת
            DateTime d_in = tc.Date1;
            DateTime d_out = tc.Date1;
            sh.WrkrNumber = tc.WorkerNumber;
            sh.WHDate = tc.Date1.DateToINT_YYYYMMDD();
            sh.WHIn = UTILS.ConvertTime(tc.IN);
            sh.WHOut = UTILS.ConvertTime(tc.OUT);
            string[] arr = tc.IN.Split(':');
            d_in = d_in.AddHours(Convert.ToInt32(arr[0])).AddMinutes(Convert.ToInt32(arr[1]));
            arr = tc.OUT.Split(':');
            d_out = d_out.AddHours(Convert.ToInt32(arr[0])).AddMinutes(Convert.ToInt32(arr[1]));
            if (d_in > d_out)
            {
                d_out = d_out.AddDays(1);
                sh.WHOut = UTILS.ConvertOver24(sh.WHOut);
            }
            sh.WHTotalHours = Math.Round(Convert.ToDecimal((d_out - d_in).TotalHours), 2);

            if (d_in.DayOfWeek == DayOfWeek.Saturday)
            {
                sh.WH200 = sh.WHTotalHours;
            }
            else
            {
                if (sh.WHTotalHours <= 8)
                {
                    sh.WH100 = sh.WHTotalHours;
                }
                else
                {
                    decimal TotalHours = sh.WHTotalHours;
                    if (TotalHours > 8)
                    {
                        sh.WH100 = 8;
                        TotalHours -= 8;
                    }
                    if (TotalHours <= 2)
                    {
                        sh.WH125 = TotalHours;
                        TotalHours = 0;
                    }
                    else
                    {
                        sh.WH125 = 2;
                        TotalHours -= 2;
                    }
                    if (TotalHours > 0)
                    {
                        sh.WH150 = TotalHours;
                        TotalHours = 0;
                    }
                }
            }
            return sh;
        }

        public static TableCSV FromCsv(string csvLine)
        {
            TableCSV tc = new TableCSV();
            string[] values = csvLine.Split(',');
            tc.WorkerNumber = Convert.ToInt32(values[0]);
            tc.Date1 = Convert.ToDateTime(values[1]);
            tc.IN = values[2];
            tc.OUT = values[3];
            return tc;
        }
    }
}

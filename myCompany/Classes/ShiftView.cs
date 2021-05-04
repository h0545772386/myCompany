using System;

namespace myCompany
{
 
    public class ShiftView
    {
        public int WHId { get; set; }

        public int WrkrNumber { get; set; }

        public DateTime WHDate { get; set; }   
        public DayOfWeek DOW { get; set; }   

        public string WHIn { get; set; }   // HHMM

        public string WHOut { get; set; }  // HHMM

        public decimal WHTotalHours { get; set; }

        public string FullName { get; set; }

        public decimal WH100 { get; set; }

        public decimal WH125 { get; set; }

        public decimal WH150 { get; set; }

        public decimal WH200 { get; set; }

        public bool IsHourly { get; set; }

        public decimal HourlyPrice { get; set; }

        public decimal TripPrice { get; set; }

        public bool IsGlobally { get; set; }

        public decimal GloballyTotal { get; set; }
        public decimal DialyFeeTotal { get; set; }

        public string Error { get; set; }

        public ShiftView()
        {
            Error = "";
        }

        public Shift Convert2Shift()
        {
            Shift sh = new Shift();
            sh.WHId = this.WHId;
            sh.WrkrNumber = this.WrkrNumber;
            sh.WHDate = this.WHDate.DateToINT_YYYYMMDD();
            sh.WHIn = this.WHIn;
            sh.WHOut = this.WHOut;
            sh.WHTotalHours = this.WHTotalHours;
            sh.WH100 = this.WH100;
            sh.WH125 = this.WH125;
            sh.WH150 = this.WH150;
            sh.WH200 = this.WH200;
            sh.IsHourly = this.IsHourly;
            sh.HourlyPrice = this.HourlyPrice;
            sh.TripPrice = this.TripPrice;
            sh.IsGlobally = this.IsGlobally;
            sh.GloballyTotal = this.GloballyTotal;
            return sh;
        }

    }
}

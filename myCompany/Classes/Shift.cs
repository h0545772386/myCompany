namespace myCompany
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Shift
    {
        [Key]
        public int WHId { get; set; }

        public int WrkrNumber { get; set; }

        public int WHDate { get; set; }   // YYYYMMDD

        [StringLength(10)]
        public string WHIn { get; set; }   // HHMM

        [StringLength(10)]
        public string WHOut { get; set; }  // HHMM

        public decimal WHTotalHours { get; set; }

        public decimal WH100 { get; set; }

        public decimal WH125 { get; set; }

        public decimal WH150 { get; set; }

        public decimal WH200 { get; set; }

        public bool IsHourly { get; set; }

        public decimal HourlyPrice { get; set; }

        public decimal TripPrice { get; set; }

        public bool IsGlobally { get; set; }

        public decimal GloballyTotal { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [NotMapped]
        public int WHMonth { get; set; }

        public Shift()
        {
            Status = "פעיל";
        }

        public ShiftView Convert2ShiftView()
        {
            ShiftView shv = new ShiftView();
            shv.WHId = this.WHId;
            shv.WrkrNumber = this.WrkrNumber;
            shv.WHDate = this.WHDate.INT2Date();
            shv.DOW = shv.WHDate.DayOfWeek;
            shv.WHIn = this.WHIn;
            shv.WHOut = this.WHOut;
            shv.WHTotalHours = this.WHTotalHours;
            shv.WH100 = this.WH100;
            shv.WH125 = this.WH125;
            shv.WH150 = this.WH150;
            shv.WH200 = this.WH200;
            shv.IsHourly = this.IsHourly;
            shv.HourlyPrice = this.HourlyPrice;
            shv.TripPrice = this.TripPrice;
            shv.IsGlobally = this.IsGlobally;
            shv.GloballyTotal = this.GloballyTotal;
            return shv;
        }
    }
}

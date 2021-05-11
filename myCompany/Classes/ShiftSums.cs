using System;

namespace myCompany
{
    public class ShiftSums
    {
        public int WrkrNumber { get; set; }

        public string FullName { get; set; }

        public int WHDate { get; set; }   // YYYYMMDD

        public int WHMonth { get; set; }

        public decimal WH100Tot { get; set; }

        public decimal WH125Tot { get; set; }

        public decimal WH150Tot { get; set; }

        public decimal WH200Tot { get; set; }

        public decimal HourlyPrice { get; set; }

        public decimal TripPrice { get; set; }

        public decimal DialyTot { get; set; }

        public void CalcDialyTotals()
        {
            DialyTot = Math.Round(Convert.ToDecimal(WH100Tot * HourlyPrice +
                       WH125Tot * HourlyPrice * (decimal)1.25 +
                       WH150Tot * HourlyPrice * (decimal)1.50 +
                       WH200Tot * HourlyPrice * (decimal)2.00 +
                       TripPrice), 2);
        }

    }
}

namespace myCompany
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    public class Shift
    {
        [Key]
        public int WHId { get; set; }

        [StringLength(100)]
        public string DOW { get; set; }

        public int WHDate { get; set; }

        public int Numer { get; set; }

        public int WHIn { get; set; }

        public int WHOut { get; set; }

        public decimal WHTotalHours { get; set; }

        public decimal WH100P { get; set; }

        public decimal WH125P { get; set; }

        public decimal WH150P { get; set; }

        public decimal WH175P { get; set; }

        public decimal WH200P { get; set; }

        public int WrkrNumber { get; set; }

        public bool IsHourly { get; set; }

        public decimal HourlyPrice { get; set; }

        public decimal TripPrice { get; set; }

        public bool IsGlobally { get; set; }

        public decimal GloballyTotal { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

    }
}

namespace myCompany
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Worker
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WrkrNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string IDN { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string UserPass { get; set; }

        public bool IsSysAdmin { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Phone1 { get; set; }

        [StringLength(100)]
        public string Phone2 { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        public bool IsManager { get; set; }

        public int RolId { get; set; }

        public int DeprId { get; set; }

        public int ManagerId { get; set; }

        [StringLength(200)]
        public string City1 { get; set; }

        [StringLength(200)]
        public string Address1 { get; set; }

        public int BankNumber { get; set; }

        public int BnkBrnchNum { get; set; }

        [StringLength(100)]
        public string BnkAccountNum { get; set; }

        [StringLength(100)]
        public string Gender { get; set; }

        public decimal HourlyPrice { get; set; }

        public decimal TripPrice { get; set; }

        public bool IsHourly { get; set; }

        public bool IsGlobally { get; set; }

        public decimal GloballyTotal { get; set; }

        [NotMapped]
        public string ManagerFullName { get; set; }

        [NotMapped]
        public string DeprName { get; set; }

        [NotMapped]
        public string RoleName { get; set; }


        public Worker()
        {
            Phone1 = "";
            Phone2 = "";
            Status = "פעיל";
        }
    }
}

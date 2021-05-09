using System.ComponentModel.DataAnnotations;

namespace myCompany
{
    // ניהול המחלקות בארגון
    //  יש טבלה בבסיס הנתונים שמחזיקה את שמות המחלקות בחברה

    public partial class Department
    {
        [Key]
        public int DeprId { get; set; }

        [Required]
        [StringLength(100)]
        public string DeprName { get; set; }

        [StringLength(300)]
        public string DeprDescr { get; set; }

        [StringLength(100)]
        public string Status { get; set; }


        public Department()
        {
            Status = "פעיל";
        }
    }
}

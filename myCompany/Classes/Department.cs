using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCompany
{
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

        [NotMapped]
        public ViewState VS { get; set; }

        public Department()
        {
            VS = ViewState.View;
            Status = "פעיל";
        }
    }
}

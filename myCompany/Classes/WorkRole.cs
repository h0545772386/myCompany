using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace myCompany
{
    public partial class WorkRole
    {
        [Key]
        public int RolId { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }

        [StringLength(300)]
        public string RoleDescr { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [NotMapped]
        public ViewState VS { get; set; }

        public WorkRole()
        {
            VS = ViewState.View;
            Status = "פעיל";
        }
    }
}

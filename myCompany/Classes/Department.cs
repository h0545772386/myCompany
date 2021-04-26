using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

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
    }
}

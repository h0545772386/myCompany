using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace myCompany
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<WorkRole> WorkRoles { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                .Property(e => e.HourlyPrice)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Worker>()
                .Property(e => e.TripPrice)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Worker>()
                .Property(e => e.GloballyTotal)
                .HasPrecision(10, 2);
        }
    }
}

namespace myCompany.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<myCompany.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(myCompany.Model1 context)
        {
            Worker w = new Worker()
            {
                WrkrNumber = 1,
                IDN = "000000000",
                FullName = "אברהים עלי",
                UserName = "ibrahim.a",
                UserPass = "123456",
                IsSysAdmin = true,
                Email = "ibrahim.a@gmail.com",
                Phone1 = "0521111111",
                Phone2 = "0542222222",
                Status = "Active"
            };
            var w1 = context.Workers.FirstOrDefault(tt => tt.WrkrNumber == 1);
            if (w1 != null)
                return;
            context.Workers.Add(w);
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

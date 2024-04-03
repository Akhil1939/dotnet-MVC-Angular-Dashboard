namespace MVC_Angular_demo.Migrations
{
    using MVC_Angular_demo.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Angular_demo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC_Angular_demo.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            // Seed roles data
            context.Roles.AddOrUpdate(
                r => r.Name,
                new Roles { Name = "Admin" },
                new Roles { Name = "User" }
            );

            // Save changes to the database
            context.SaveChanges();
        }
    }
}

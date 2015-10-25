namespace Stinger.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Stingers.Models;

    public sealed class Configuration : DbMigrationsConfiguration<StingerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StingerDbContext context)
        {
            // CREATE ADMIN ROLE
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var adminRole = new IdentityRole() { Name = "Admin" };

                manager.Create(adminRole);
            }

            // CREATE ADMIN USER 
            // TODO: PREFERABLE TO LOAD USER CREDENTIALS FROM AN EXTERNAL FILE
            if (!context.Users.Any())
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var stingerAdmin = new User() { UserName = "admin" };

                manager.Create(stingerAdmin, "password");
                manager.AddToRole(stingerAdmin.Id, "Admin");
            }
        }
    }
}

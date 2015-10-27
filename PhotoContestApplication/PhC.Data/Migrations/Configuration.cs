namespace PhC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true; // TODO FALSE IN PRODUCTION
            ContextKey = "PhC.Data.ApplicationDbContext"; 
            
        }

        protected override void Seed(ApplicationDbContext context)
        {

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var roleCreateResult =
                  roleManager.Create(new IdentityRole("Admin"));
                if (!roleCreateResult.Succeeded)
                {
                    throw new Exception(string.Join("; ", roleCreateResult.Errors));
                }
            }

            if (!(context.Users.Any(u => u.UserName == "Admin")))
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var userToInsert = new User { UserName = "Admin", Email = "admin@admin.com" };
                var userCreate = userManager.Create(userToInsert, "Password@123");
                if (!userCreate.Succeeded)
                {
                    throw new Exception(string.Join("; ", userCreate.Errors));
                }
                var addAdminRoleResult = userManager.AddToRole(userToInsert.Id, "Admin");
                if (!addAdminRoleResult.Succeeded)
                {
                    throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
                }

            }

        }
    }
}

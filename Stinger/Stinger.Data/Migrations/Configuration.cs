namespace Stinger.Data.Migrations
{
    using System.Data.Entity.Migrations;
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
            // TODO: ADD DEFAULT ADMIN

            //if (!context.Users.Any())
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var stingerAdmin = new ApplicationUser() { UserName = "admin" };
            //}
        }
    }
}

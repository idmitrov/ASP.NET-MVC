namespace HW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Enum;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // USERS
            if (!context.Users.Any())
            {
                const string defaultPassword = "password";
                var rand = new Random();

                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                for (int i = 0; i < 10; i++)
                {
                    var username = GenerateUsername("user", i);

                    var user = new ApplicationUser()
                    {
                        FirstName = "Georgi",
                        LastName = "Georgiev" + i,
                        UserName = username,
                        Age = rand.Next(15, 41),
                        Address = "Kaspichan, St.Kaspichan No: " + i,
                        Email = username,
                        PhoneNumber = "+359 899 " + rand.Next(0, 100) + " " + rand.Next(0, 100) + " " + rand.Next(0, 100),
                        Status = (UserStatus)rand.Next(0, 4)
                    };

                    manager.Create(user, defaultPassword);
                }
            }

            // CITIES
            if (!context.Cities.Any())
            {
                using (var reader = new StreamReader(
                    HttpContext.Current.Server.MapPath("~/Content/CitiesList/Cities.txt"), Encoding.UTF8))
                {
                    var cities = reader.ReadToEnd().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var city in cities)
                    {
                        context.Cities.AddOrUpdate(c => c.Name, new City()
                        {
                            Name = city
                        });
                    }
                }
            }
        }

        // GENERATE USERNAME
        private static string GenerateUsername(string username = "user", int usernameNumberCount = 0)
        {
            return string.Format("{0}{1}@example.com", username, usernameNumberCount);
        }
    }
}

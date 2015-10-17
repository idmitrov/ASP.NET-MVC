namespace Bee.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class BeeDbContext : IdentityDbContext<User>
    {
        public BeeDbContext()
            : base("BeeDbContext", false)
        {
        }

        public IDbSet<Buzz> Buzzes { get; set; }

        public static BeeDbContext Create()
        {
            return new BeeDbContext();
        }
    }
}
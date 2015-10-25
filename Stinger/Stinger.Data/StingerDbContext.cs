namespace Stinger.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;
   
    using Migrations;
    using Stingers.Models;

    public class StingerDbContext : IdentityDbContext<User>
    {
        public StingerDbContext()
            : base("Stinger", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StingerDbContext, Configuration>());
        }

        // STINGS
        public IDbSet<Sting> Stings { get; set; }

        // RE-STINGS
        public IDbSet<ReSting> ReStings { get; set; }

        // REPLIES
        public IDbSet<Reply> Replies { get; set; }

        // MESSAGES
        public IDbSet<Message> Messages { get; set; }

        // REPORTS
        public IDbSet<Report> Reports { get; set; }

        // NOTIFICATIONS
        public IDbSet<Notification> Notifications { get; set; }

        // FAVORITES
        public IDbSet<Favorite> Favorites { get; set; }

        // CREATE
        public static StingerDbContext Create()
        {
            return new StingerDbContext();
        }

        // MODEL BUILDER
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // STING => REPORTS => STING
            modelBuilder.Entity<Sting>()
                .HasMany(s => s.Reports)
                .WithRequired(r => r.Sting)
                .WillCascadeOnDelete(false);

            // USER => MESSAGES => RECIPIENT
            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithRequired(m => m.Recipient);

            // USER => MESSAGES => AUTHOR
            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithRequired(m => m.Author);

            // USER => FOLLOWERS
            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany()
                .Map(f =>
                {
                    f.MapLeftKey("UserId");
                    f.MapRightKey("FollowerId");
                    f.ToTable("UsersFollowers");
                });

            // USER => FOLLOWINGS
            modelBuilder.Entity<User>()
                .HasMany(u => u.Followings)
                .WithMany()
                .Map(f =>
                {
                    f.MapLeftKey("UserId");
                    f.MapRightKey("FollowingUserId");
                    f.ToTable("UsersFollowings");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
namespace PhC.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Model;


    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("PhCConnection", false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Contest> Contests { get; set; }
        public IDbSet<ContestEntry> ContestEntries { get; set; }
        public IDbSet<Vote> Votes { get; set; }
        public IDbSet<RewardStrategy> RewardStrategies { get; set; }
        public IDbSet<Prize> Prizes { get; set; }
        public IDbSet<VotingStrategy> VotingStrategies { get; set; }
        public IDbSet<ParticipationStrategy> ParticipationStrategies { get; set; }
        public IDbSet<DeadlineStrategy> DeadlineStrategies { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Contest>().HasMany(c => c.ContestEntries).WithRequired(ce => ce.Contest).WillCascadeOnDelete(false);
            //    modelBuilder.Entity<Contest>().HasMany(c => c.Winners).WithRequired(w => w.WonContest).WillCascadeOnDelete(false);
            modelBuilder.Entity<ContestEntry>().HasOptional(ce => ce.WonContest);
            modelBuilder.Entity<User>().HasMany(u => u.ContestsCreated).WithRequired(c => c.Creator).WillCascadeOnDelete(false);

            modelBuilder.Entity<Contest>()
                  .HasMany<User>(c => c.Participants)
                  .WithMany(p => p.ContestsParticipated)
                  .Map(pc =>
                           {
                               pc.MapLeftKey("ContestId");
                               pc.MapRightKey("UserId");
                               pc.ToTable("ContestsParticipants");
                           });

            base.OnModelCreating(modelBuilder);
        }

    }
}

namespace PhC.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Contracts;
    using Model;

    public class PhcData : IPhcData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public PhcData()
            : this(new ApplicationDbContext())
        {
        }

        public PhcData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        // CONTESTS
        public IRepository<Contest> Contests
        {
            get
            {
                return this.GetRepository<Contest>();
            }
        }

        // CONTEST ENTITIES
        public IRepository<ContestEntry> ContestEntries
        {
            get
            {
                return this.GetRepository<ContestEntry>();
            }
        }

        // VOTES
        public IRepository<Vote> Votes
        {
            get
            {
                return this.GetRepository<Vote>();
            }
        }

        // REWARD STRATEGIES
        public IRepository<RewardStrategy> RewardStrategies
        {
            get
            {
                return this.GetRepository<RewardStrategy>();
            }
        }

        // PRIZES
        public IRepository<Prize> Prizes
        {
            get
            {
                return this.GetRepository<Prize>();
            }
        }

        // VOTINGS STRATEGIES
        public IRepository<VotingStrategy> VotingStrategies
        {
            get
            {
                return this.GetRepository<VotingStrategy>();
            }
        }

        // PARTICIPATION STRATEGIES
        public IRepository<ParticipationStrategy> ParticipationStrategies
        {
            get
            {
                return this.GetRepository<ParticipationStrategy>();
            }
        }

        // DEADLINE STRATEGIES
        public IRepository<DeadlineStrategy> DeadlineStrategies
        {
            get
            {
                return this.GetRepository<DeadlineStrategy>();
            }
        }

        // SAVE
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        // GET REPOSITORY
        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(PhcRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}

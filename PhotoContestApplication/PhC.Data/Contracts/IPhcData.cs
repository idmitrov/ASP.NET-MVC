namespace PhC.Data.Contracts
{
    using Model;

    public interface IPhcData
    {
        IRepository<Contest> Contests { get; }

        IRepository<ContestEntry> ContestEntities { get; }

        IRepository<Vote> Votes { get; }

        IRepository<RewardStrategy> RewardStrategies { get; }
        
        IRepository<Prize> Prizes { get; }
        
        IRepository<VotingStrategy> VotingStrategies { get; }
        
        IRepository<ParticipationStrategy> ParticipationStrategies { get; }
        
        IRepository<DeadlineStrategy> DeadlineStrategies { get; }

        int SaveChanges();
    }
}

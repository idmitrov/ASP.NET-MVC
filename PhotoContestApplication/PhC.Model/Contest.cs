namespace PhC.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Contest
    {
        private ICollection<ContestEntry> _contestEntries;

        private ICollection<User> _participants;
        private ICollection<ContestEntry> _winners;

        private ParticipationStrategy _participationStrategy;
        private VotingStrategy _votingStrategy;
        private RewardStrategy _rewardStrategy;
        private DeadlineStrategy _deadlineStrategy;


        public Contest(
            EntryType participationType = EntryType.Open,
            EntryType votingType = EntryType.Open,
            RankingType rewardType = RankingType.Multiple,
            DeadlineType deadlineType = DeadlineType.Time)
        {
            this._winners = new HashSet<ContestEntry>();
            this._contestEntries = new HashSet<ContestEntry>();
            this._participants = new HashSet<User>();

            this._participationStrategy = new ParticipationStrategy(participationType);
            this._votingStrategy = new VotingStrategy(votingType);
            this._rewardStrategy = new RewardStrategy(rewardType);
            this._deadlineStrategy = new DeadlineStrategy(deadlineType);
        }

        // ID
        public int Id { get; set; }

        // TITLE
        [Required]
        public string Title { get; set; }

        // DESCRIPTION
        [Required]
        public string Description { get; set; }

        // STATE
        [Required]
        public ContestState State { get; set; }

        //DATE CREATED
        [Required]
        public DateTime CreatedOn { get; set; }

        // CREATOR
        [Required]
        public string CreatorId { get; set; }
        public virtual User Creator { get; set; }

        // REWARD STRATEGY
        [Required]
        public virtual RewardStrategy RewardStrategy
        {
            get { return this._rewardStrategy; }
            set { this._rewardStrategy = value; }
        }

        // VOTING STRATEGY
        [Required]
        public virtual VotingStrategy VotingStrategy
        {
            get { return this._votingStrategy; }
            set { this._votingStrategy = value; }
        }

        // PARTICIPATION STRATEGY
        [Required]
        public virtual ParticipationStrategy ParticipationStrategy
        {
            get { return this._participationStrategy; }
            set { this._participationStrategy = value; }
        }

        // DEADLINE STATEGY
        [Required]
        public virtual DeadlineStrategy DeadlineStrategy
        {
            get { return this._deadlineStrategy; }
            set { this._deadlineStrategy = value; }
        }

        // WINNERS
        public virtual ICollection<ContestEntry> Winners
        {
            get { return this._winners; }
            set { this._winners = value; }
        }

        // CONTEST ENTRIES
        public virtual ICollection<ContestEntry> ContestEntries
        {
            get { return this._contestEntries; }
            set { this._contestEntries = value; }
        }

        // PARTICIPANTS
        public virtual ICollection<User> Participants
        {
            get { return this._participants; }
            set { this._participants = value; }
        }

    }
}

namespace PhC.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;

    public class DeadlineStrategy : IContestStrategy<DeadlineType>
    {
        public DeadlineStrategy(DeadlineType type)
        {
            this.Type = type;
        }

        // ID
        [Key, ForeignKey("Contest")]
        public int Id { get; set; }

        // CONTEST
        public virtual Contest Contest { get; set; }

        // TYPE
        [Required]
        public DeadlineType Type { get; set; }
        
        // TIME
        public TimeSpan? TimeSpan { get; set; }
        
        // PARTICIPATION COUNT
        public int? ParticipantCount { get; set; }
    }
}

namespace PhC.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;

    public class VotingStrategy: IContestStrategy<EntryType>
    {
        private ICollection<User> _commettee;

        public VotingStrategy(EntryType type)
        {
            if (type == EntryType.Close)
            {
                this._commettee = new HashSet<User>();    
            }
            
        }
        [Key, ForeignKey("Contest")]
        public int Id { get; set; }

        [Required]
        public EntryType Type { get; set; }

        public virtual Contest Contest { get; set; }

        //Collection of users who are allowed to vote
        public virtual ICollection<User> Commettee {
            get { return this._commettee; }
            set { this._commettee = value; }
        }
    }
}

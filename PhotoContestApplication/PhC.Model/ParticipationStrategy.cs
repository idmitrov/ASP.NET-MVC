namespace PhC.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;

    public class ParticipationStrategy : IContestStrategy<EntryType>
    {
        private ICollection<User> _allowedUsers;

        public ParticipationStrategy(EntryType type)
        {
             if (type == EntryType.Close)
             {
                 this._allowedUsers = new HashSet<User>();
             }
        }

        // ID
        [Key, ForeignKey("Contest")]
        public int Id { get; set; }

        // CONTEST
        public virtual Contest Contest { get; set; }
        
        // TYPE
        [Required]
        public EntryType Type { get; set; }

        // Collection of users who are allowed to participate
        public virtual ICollection<User> AllowedUsers
        {
            get { return this._allowedUsers; }
            set { this._allowedUsers = value; }
        }
    }
}

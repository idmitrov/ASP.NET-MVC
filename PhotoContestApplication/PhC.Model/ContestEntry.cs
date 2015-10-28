namespace PhC.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ContestEntry
    {
        private ICollection<Vote> _votes;

        public ContestEntry()
        {
            this.IsWinner = false;
            this.WinningPlace = null;
            this._votes = new HashSet<Vote>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public DateTime Upploaded { get; set; }
        
        [Required]
        public string PhotoUrl { get; set; }
        
        [Required]
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }

        [Required]
        public int ContestId { get; set; }
        public virtual Contest Contest { get; set; }

        public int? WonContestId { get; set; }
        public virtual Contest WonContest { get; set; }

        public bool IsWinner { get; private set; }

        public int? WinningPlace { get; private set; }

        public virtual ICollection<Vote> Votes
        {
            get { return this._votes; }
            set { this._votes = value; }
        }

        public void Win(int? winingPlace = null )
        {
            this.IsWinner = true;
            this.WinningPlace = winingPlace;
        }
    }
}

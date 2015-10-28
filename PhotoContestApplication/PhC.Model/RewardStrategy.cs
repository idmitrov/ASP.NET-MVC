namespace PhC.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;

    public class RewardStrategy : IContestStrategy<RankingType>
    {
        private ICollection<Prize> _prizes;
        public RewardStrategy(RankingType type)
        {
            this.Type = type;
            if (type == RankingType.Multiple)
            {
                this._prizes = new HashSet<Prize>();
            }
        }

        [Key, ForeignKey("Contest")]
        public int Id { get; set; }

        public virtual Contest Contest { get; set; }
        
        public RankingType Type { get; set; }
        
        public virtual ICollection<Prize> Prizes 
        {
            get { return this._prizes; }
            set { this._prizes = value; }
        }

    }
}

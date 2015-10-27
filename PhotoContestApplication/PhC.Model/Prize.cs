namespace PhC.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Prize
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int RewardStrategyId { get; set; }
        public virtual RewardStrategy RewardStrategy { get; set; }

    }
}

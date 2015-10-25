namespace Stingers.Models
{
    using System.ComponentModel.DataAnnotations;

    public  class Favorite
    {
        [Key]
        public int StingId { get; set; }
        public virtual Sting Sting { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }
    }
}

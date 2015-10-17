namespace Bee.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Buzz
    {
        // ID
        [Key]
        public int Id { get; set; }

        // CONTENT
        [Required]
        public string Content { get; set; }

        // POSTED ON
        public DateTime PostedOn { get; set; }

        // AUTHOR
        [Required]
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}

namespace Stingers.Models.Abstract
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class StingMessage
    {
        // ID
        [Key]
        public int Id { get; set; }

        // CONTENT
        [Required]
        public string Content { get; set; }

        // DATE
        public DateTime Date { get; set; }

        // AUTHOR
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}

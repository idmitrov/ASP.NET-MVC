namespace PhC.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        // ID
        [Key]
        public int Id { get; set; }

        // CONTENT
        [Required]
        public string Content { get; set; }

        // RECIPIENT
        public string RecipientId { get; set; }
        public User Recipient { get; set; }
    }
}

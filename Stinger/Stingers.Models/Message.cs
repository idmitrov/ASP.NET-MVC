namespace Stingers.Models
{
    using Abstract;

    public class Message : StingMessage
    {
        // RECIPIENT
        public string RecipientId { get; set; }
        public virtual User Recipient { get; set; }
    }
}

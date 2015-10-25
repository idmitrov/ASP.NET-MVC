    namespace Stingers.Models
{
    using Abstract;
    using Enum;

    public class Notification : StingMessage
    {
        // NOTIFICATION TYPE
        public NotificationType Type { get; set; }

        // RECIPIENT
        public string RecipientId { get; set; }
        public virtual User Recipient { get; set; }
    }
}

namespace Stingers.Models
{
    using Abstract;
    using Enum;

    public class Report : StingMessage
    {
        // STING
        public int StingId { get; set; }
        public Sting Sting { get; set; }

        // REPLY
        public int ReplyId { get; set; }
        public Reply Reply { get; set; }

        // REPORT STATUS
        public Status Status { get; set; }
    }
}

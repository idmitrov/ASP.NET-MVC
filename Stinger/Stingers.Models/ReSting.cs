namespace Stingers.Models
{
    using Abstract;

    public class ReSting : StingMessage
    {
        public int StingId { get; set; }
        public virtual Sting Sting { get; set; }
    }
}

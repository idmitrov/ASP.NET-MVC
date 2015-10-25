namespace Stingers.Models
{
    using System.Collections.Generic;

    using Abstract;

    public class Reply : StingMessage
    {
        private ICollection<Report> _reports;

        public Reply()
        {
            this._reports = new HashSet<Report>();
        }

        // REPLIED TO STING
        public int StingId { get; set; }
        public virtual Sting Sting { get; set; }

        // REPORTS
        public virtual ICollection<Report> Reports
        {
            get { return this._reports; }
            set { this._reports = value; }
        }
    }
}

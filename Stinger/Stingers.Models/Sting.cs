namespace Stingers.Models
{
    using System.Collections.Generic;

    using Abstract;

    public class Sting : StingMessage
    {
        private ICollection<Reply> _replies;
        private ICollection<Report> _reports;

        public Sting()
        {
            this._replies = new HashSet<Reply>();
            this._reports = new HashSet<Report>();
        }

        // REPLIES
        public virtual ICollection<Reply> Replies
        {
            get { return this._replies; }
            set { this._replies = value; }
        }

        // REPORTS
        public virtual ICollection<Report> Reports
        {
            get { return this._reports; }
            set { this._reports = value; }
        }
    }
}

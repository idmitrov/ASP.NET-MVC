namespace PhC.Model
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {

        private ICollection<Contest> _contestsCreated;
        private ICollection<Contest> _contestsParticipated;
        private ICollection<ContestEntry> _contestEntries;
        private ICollection<Vote> _votes;
        private ICollection<VotingStrategy> _votingStrategiesCommette;
        private ICollection<ParticipationStrategy> _participationStrategies;
		private ICollection<Notification> _notifications;


        public User()
        {
            this._contestsParticipated = new HashSet<Contest>();
            this._contestsCreated = new HashSet<Contest>();
            this._contestEntries = new HashSet<ContestEntry>();
            this._votes = new HashSet<Vote>();
            this._votingStrategiesCommette = new HashSet<VotingStrategy>();
            this._participationStrategies = new HashSet<ParticipationStrategy>();
			this._notifications = new HashSet<Notification>();
        }

        
        public virtual ICollection<Contest> ContestsCreated 
        {
            get { return this._contestsCreated; }
            set { this._contestsCreated = value; }
        }

        
        public virtual ICollection<ContestEntry> ContestEntries
        {
            get { return this._contestEntries; }
            set { this._contestEntries = value; }
        }
        
        //votes given by the user
        public virtual ICollection<Vote> Votes
        {
            get { return this._votes; }
            set { this._votes = value; }
        }

        //contests in which participated
        public virtual ICollection<Contest> ContestsParticipated
        {
            get { return this._contestsParticipated; }
            set { this._contestsParticipated = value; }
        }

        //Collection ot strategy/contest in which user is allowed to vote by the owner 
        public virtual ICollection<VotingStrategy> VotingStrategiesCommette 
        {
            get { return this._votingStrategiesCommette; }
            set { this._votingStrategiesCommette = value; } 
        }
        
        //Collection ot strategy/contest in which user is allowed to participate by the owner 
        public virtual ICollection<ParticipationStrategy> ParticipationStrategies
        {
            get { return this._participationStrategies; }
            set { this._participationStrategies = value; }
        } 
      
		public virtual ICollection<Notification> Notifications 
		{
			get { return this._notifications; }
			set {this._notifications = value;}
		}







        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}

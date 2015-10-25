namespace Stingers.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Security.Claims;
    using Enum;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private const string DefaultProfileImage = "Content/images/default-stinger-profile.jpg";

        private ICollection<Sting> _stings;
        private ICollection<ReSting> _reStings; 
        private ICollection<Message> _messages;
        private ICollection<Notification> _notifications;
        private ICollection<User> _followers;
        private ICollection<User> _followings;
        private ICollection<Favorite> _favorites;

        public User()
        {
            this._stings = new HashSet<Sting>();
            this._reStings = new HashSet<ReSting>();
            
            this._messages = new HashSet<Message>();
            this._notifications = new HashSet<Notification>();
            this._followers = new HashSet<User>();
            this._followings = new HashSet<User>();
            this._favorites = new HashSet<Favorite>();
            
            this.Avatar = DefaultProfileImage;
        }

        // GENDER
        public Gender Gender { get; set; }

        // AVATAR
        public string Avatar { get; set; }

        // STINGS
        public virtual ICollection<Sting> Stings
        {
            get { return this._stings; }
            set { this._stings = value; }
        }

        // RE-STINGS
        public virtual ICollection<ReSting> ReStings
        {
            get { return this._reStings; }
            set { this._reStings = value; }
        }

        // FAVORITES
        public virtual ICollection<Favorite> Favorites
        {
            get { return this._favorites; }
            set { this._favorites= value; }
        }

        // MESSAGES
        public virtual ICollection<Message> Messages
        {
            get { return this._messages; }
            set { this._messages = value; }
        }

        // NOTIFICATIONS
        public virtual ICollection<Notification> Notifications
        {
            get { return this._notifications; }
            set { this._notifications = value; }
        }

        // FOLLOWERS
        public virtual ICollection<User> Followers
        {
            get { return this._followers; }
            set { this._followers = value; }
        }

        // FOLLOWINGS
        public virtual ICollection<User> Followings
        {
            get { return this._followings; }
            set { this._followings= value; }
        }

        // GENERATE IDENTITY
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            return userIdentity;
        }
    }
}

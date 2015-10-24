namespace HW.Models
{
    using System.Threading.Tasks;
    using System.Security.Claims;
    using Enum;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser
    {
        private const string DefaultProfileImageUrl = "Content/Images/Default-Profile-Image.jpg";

        public ApplicationUser()
        {
            this.ProfileImage = DefaultProfileImageUrl;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public UserStatus Status { get; set; }

        public string ProfileImage { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            return userIdentity;
        }
    }

}

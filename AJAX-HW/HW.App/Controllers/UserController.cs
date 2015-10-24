namespace HW.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using HW.Models.Enum;
    using Models;

    public class UserController : BaseController
    {
        // GET: Users
        public ActionResult Index()
        {
            var users = this.Data.Users
                .OrderBy(u => u.LastName)
                .Select(u => new UserListViewModel()
                {
                    Id = u.Id,
                    Name = u.FirstName + " " + u.LastName
                });
           
            return this.View(users);
        }

        // GET USER DETAILS
        public ActionResult UserDetails(string userId)
        {
            var userDetails = this.Data.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserProfileViewModel()
                {
                    ProfileImage = u.ProfileImage,
                    Address = u.Address,
                    Phone = u.PhoneNumber,
                    Email = u.Email,
                    Status = u.Status.ToString(),
                    Age = u.Age
                });

            return this.Json(userDetails, JsonRequestBehavior.AllowGet);
        }
    }
}
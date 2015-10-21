namespace HW.App.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Models;

    [Authorize]
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            var loggedUserUsername = this.Data.Users.Find(this.User.Identity.GetUserId()).UserName;

            return this.View(new LoggedUserViewModel() { Username = loggedUserUsername });
        }
    }
}
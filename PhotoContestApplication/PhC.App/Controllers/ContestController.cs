namespace PhC.App.Controllers
{
    using System.Web.Mvc;
    
    [Authorize]
    public class ContestController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetContest()
        {
            return this.Content("SOON...");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult NewContest()
        {
            return this.Content("NEW CONTEST CREATED");
        }
    }
}
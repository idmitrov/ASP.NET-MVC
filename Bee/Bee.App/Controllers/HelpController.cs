namespace Bee.App.Controllers
{
    using System.Web.Mvc;

    public class HelpController : Controller
    {
        // GET: Help
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
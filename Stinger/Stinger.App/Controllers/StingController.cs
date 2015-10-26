namespace Stinger.App.Controllers
{
    using System.Web.Mvc;

    [ValidateAntiForgeryToken]
    public class StingController : Controller
    {
        public ActionResult NewSting()
        {
            return this.RedirectToAction("Index","Home");
        }
    }
}
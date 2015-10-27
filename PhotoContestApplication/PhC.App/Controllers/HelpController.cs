namespace PhC.App.Controllers
{
    using System.Web.Mvc;

    public class HelpController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
namespace Bee.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Models.ViewModels;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var allBuzz = this.Data.Buzzes.All().Select(b => new BuzzesFullViewModel
            {
                Content = b.Content
            }).ToList();

            return this.View(allBuzz);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
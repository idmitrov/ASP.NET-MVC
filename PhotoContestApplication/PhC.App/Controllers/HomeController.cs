namespace PhC.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Model;
    using Model.Enums;
    using Models.ViewModels;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(GetContestsLIst("active"));
        }

        public ActionResult PastContest()
        {
            return View(GetContestsLIst("past"));
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

        [NonAction]
        public IQueryable<ContestConciseViewModel> GetContestsLIst(string type)
        {
            IQueryable<Contest> contests = this.Data.Contests.All();
            contests = type == "past" ? contests.Where(c => c.State != ContestState.Active) : contests.Where(c => c.State == ContestState.Active);
            IQueryable<ContestConciseViewModel> resultContests = contests.OrderByDescending(c => c.CreatedOn).ProjectTo<ContestConciseViewModel>();
            return resultContests;
        }
    }
}
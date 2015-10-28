namespace PhC.App.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.AspNet.Identity;
    using Model;
    using Model.Enums;
    using Models.ViewModels;

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
        public ActionResult GetContest(int entriesToSkip, string filter = "active")
        {
            System.Threading.Thread.Sleep(1000);
            var totalEntries = this.Data.Contests.All().Count();

            if (entriesToSkip < totalEntries)
            {
                const int entriesToLoad = 10;

                entriesToSkip *= entriesToLoad;

                var contests = this.Data.Contests.All();
                IQueryable<ContestConciseViewModel> result = null;

                var loggedUserId = this.User.Identity.GetUserId();

                switch (filter)
                {
                    case "active":
                        contests = contests.Where(c => c.State == ContestState.Active);
                        break;
                    case "own":
                        contests = contests
                            .Where(c => c.CreatorId == loggedUserId);
                        break;
                    case "past":
                        contests = contests.Where(c => c.State != ContestState.Active);
                        break;
                }

                result = contests.OrderByDescending(c => c.CreatedOn)
                    .Skip(entriesToSkip)
                    .Take(entriesToLoad)
                    .ProjectTo<ContestConciseViewModel>();

                return this.Json(result, JsonRequestBehavior.AllowGet);
            }

            return null;
        }

    //[ValidateAntiForgeryToken]
        //[HttpPost]
        public ActionResult NewContest()
        {
            //var context = new ApplicationDbContext();

            //for (int i = 0; i < 200; i++)
            //{
            //    var contest = new Contest()
            //    {
            //        Title = "Contest NO " + i,
            //        Description = "Contest Description",
            //        State = 0,
            //        CreatedOn = DateTime.Now,
            //        CreatorId = "2f703535-2365-4a8f-b9ea-1f1c73d0370e",
            //        RewardStrategy = new RewardStrategy(RankingType.Single),
            //        VotingStrategy = new VotingStrategy(EntryType.Open),
            //        ParticipationStrategy = new ParticipationStrategy(EntryType.Open),
            //        DeadlineStrategy = new DeadlineStrategy(DeadlineType.CountParticipants)
            //    };

            //    context.Contests.Add(contest);
            //    context.SaveChanges();
            //}



            //var contest = new Contest()
            //{
            //    Title = "My contest",
            //    Description = "asd",
            //    CreatedOn = DateTime.UtcNow,
            //    CreatorId = "3571b52e-eefb-4e22-a00b-fe0a39b016bc"
            //};


            //this.Data.Contests.Add(contest);

            //this.Data.Contests.SaveChanges();



            return this.Content("Created");
        }
    }
}
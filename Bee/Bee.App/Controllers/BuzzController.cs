namespace Bee.App.Controllers
{
    using System;
    using System.Web.Mvc;

    using Bee.Models;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;

    [Authorize]
    public class BuzzController : BaseController
    {
        // POST NEW BUZZ
        public ActionResult Buzz(BuzzBindingModel model)
        {
            try
            {
                var loggedUserId = this.User.Identity.GetUserId();
                var loggedUser = this.Data.Users.Find(loggedUserId);

                var newlyBuzz = new Buzz()
                {
                    Content = model.Content,
                    AuthorId = loggedUserId,
                    Author = loggedUser,
                    PostedOn = DateTime.UtcNow
                };

                this.Data.Buzzes.Add(newlyBuzz);
                this.Data.SaveChanges();

                return RedirectToAction("index", "Home");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
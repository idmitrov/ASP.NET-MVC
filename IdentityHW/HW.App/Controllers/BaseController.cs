namespace HW.App.Controllers
{
    using System.Web.Mvc;

    using Data;

    public class BaseController : Controller
    {
        public BaseController()
            : this(new ApplicationDbContext())
        {
        }

        public BaseController(ApplicationDbContext context)
        {
            this.Data = context;
        }

        protected ApplicationDbContext Data { get; set; }
    }
}
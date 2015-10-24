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

        public BaseController(ApplicationDbContext data)
        {
            this.Data = data;
        }

        public ApplicationDbContext Data { get; set; }
    }
}
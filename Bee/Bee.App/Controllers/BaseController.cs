namespace Bee.App.Controllers
{
    using System.Web.Mvc;
    using Data;
    using Data.Contracts;

    public abstract class BaseController : Controller
    {
        protected BaseController()
            : this(new BeeData())
        {
        }

        protected BaseController(IBeeData data)
        {
            this.Data = data;
        }

        protected IBeeData Data { get; private set; }
    }
}
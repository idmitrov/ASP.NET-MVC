namespace PhC.App.Controllers
{
    using System.Web.Mvc;

    using Data;
    using Data.Contracts;

    public abstract class BaseController : Controller
    {
        protected BaseController() 
            : this(new PhcData())
        {
        }

        protected BaseController(IPhcData data)
        {
            this.Data = data;
        }

        protected IPhcData Data { get; private set; }
    }
}
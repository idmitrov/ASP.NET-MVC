namespace PhC.App.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using App.Controllers;
    using Data;

    [Authorize(Roles = "Admin")]
    public class BaseAdminController : BaseController
    {
        
    }
}
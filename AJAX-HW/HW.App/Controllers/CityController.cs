namespace HW.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    public class CityController : BaseController
    {
        // GET: City
        public ActionResult Index()
        {
            return this.View();
        }

        // RETURN CITIES BY MATCH
        public ActionResult AutocompleteCityName(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                var cities = this.Data.Cities
               .Where(c => c.Name.StartsWith(input))
               .OrderBy(c => c.Name)
               .Select(c => c.Name).ToList();

                return this.Json(cities, JsonRequestBehavior.AllowGet);
            }

            return null;
        }
    }
}
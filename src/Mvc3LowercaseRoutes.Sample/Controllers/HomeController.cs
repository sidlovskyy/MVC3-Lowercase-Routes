using System.Web.Mvc;

namespace Mvc3LowercaseRoutes.Sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestRoute()
        {
            return View();
        }
    }
}

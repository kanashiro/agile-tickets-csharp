using System.Web.Mvc;

namespace AgileTickets.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }
    }
}

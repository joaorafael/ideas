using System.Web.Mvc;

namespace WebIdeias.Controllers
{
    public class StatsController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - Stats";

            return View();
        }
    }
}
using System.Web.Mvc;

namespace WebIdeas.Controllers
{
    public class StatsController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - Stats";

            return View();
        }
    }
}
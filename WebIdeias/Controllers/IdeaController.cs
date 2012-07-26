using System.Web.Mvc;

namespace WebIdeias.Controllers
{
    public class IdeaController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - Idea";

            return View();
        }
    }
}
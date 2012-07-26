using System.Web.Mvc;

namespace WebIdeas.Controllers
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
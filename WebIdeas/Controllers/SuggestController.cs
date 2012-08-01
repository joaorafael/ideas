using System.Web.Mvc;

namespace WebIdeas.Controllers
{
    public class SuggestController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - Suggest";

            return View();
        }
    }
}
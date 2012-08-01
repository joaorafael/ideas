using System.Web.Mvc;

namespace WebIdeas.Controllers
{
    public class HelpController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - Help";

            return View();
        }
    }
}
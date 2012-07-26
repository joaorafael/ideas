using System.Web.Mvc;

namespace WebIdeas.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - User";

            return View();
        }
    }
}
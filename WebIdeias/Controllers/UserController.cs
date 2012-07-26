using System.Web.Mvc;

namespace WebIdeias.Controllers
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
using System.Web.Mvc;

namespace WebIdeas.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - Categoria";

            return View();
        }
    }
}
using System.Web.Mvc;

namespace WebIdeias.Controllers
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
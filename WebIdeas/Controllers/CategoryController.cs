using System.Web.Mvc;

namespace WebIdeas.Controllers
{
    public class CategoryController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - Categoria";

            return View();
        }

        public ActionResult Details()
        {
            throw new System.NotImplementedException();
        }
    }
}
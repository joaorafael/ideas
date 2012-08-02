using System.Web.Mvc;
using WebIdeas.Models;

namespace WebIdeas.Controllers
{
    public class TagController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - Tags";

            return View();
        }

        public ActionResult Details(int id)
        {
            var tag = UnitOfWork.Session.Get<Tag>(id);
            ViewBag.Message = "ViewBag.Message - Tag " + tag.Name;
            return View(tag);
        }
    }
}
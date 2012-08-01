using System.Linq;
using System.Web.Mvc;
using NHibernate.Linq;
using WebIdeas.Models;

namespace WebIdeas.Controllers
{
    public class IdeaController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - Idea";

            return View();
        }

        public ActionResult Details(int id)
        {
            var idea = (from item in UnitOfWork.Session.Query<Idea>() where item.Id == id select item).First();
            return View(idea);
        }
    }
}
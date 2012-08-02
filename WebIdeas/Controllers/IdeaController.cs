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
            var idea = UnitOfWork.Session.Get<Idea>(id);
            return View(idea);
        }

        public ActionResult Edit(int id)
        {
            var idea = UnitOfWork.Session.Get<Idea>(id);
            return View(idea);
        }

        public ActionResult New()
        {
            return View();
        }
    }
}
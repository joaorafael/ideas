using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate.Linq;
using System.Linq;
using WebIdeas.Models;
using WebIdeas.ViewModels;

namespace WebIdeas.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - Home";

            var tags = (from tag in UnitOfWork.Session.Query<Tag>() select tag).ToList();
            var contributers = (from contributer in UnitOfWork.Session.Query<Contributer>() select contributer).ToList();
            var ideas = (from idea in UnitOfWork.Session.Query<Idea>() select idea).ToList();
            var lastIdeaQ = (
                from last in UnitOfWork.Session.Query<Idea>()
                select last);
            var lastIdeaOrdered = lastIdeaQ.OrderByDescending(x => x.Id);
            var lastIdea = lastIdeaOrdered.Any() ? lastIdeaOrdered.First() : null;

            return View(new HomeIndexViewModel { Tags = tags, Contributers = contributers, Ideas = ideas, LastIdea = lastIdea});
        }
    }
}

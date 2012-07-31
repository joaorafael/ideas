using System.Web.Mvc;
using NHibernate.Linq;
using System.Linq;
using WebIdeas.Models;

namespace WebIdeas.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - Home";

            var tags = (from tag in UnitOfWork.Session.Query<Tag>() select tag).ToList();
            return View(new HomeIndexViewModel{Tags = tags});
        }
    }
}

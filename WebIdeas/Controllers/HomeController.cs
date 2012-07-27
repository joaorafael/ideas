using System.Web.Mvc;
using WebIdeas.Infrastructure;
using WebIdeas.Models;

namespace WebIdeas.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - Home";

            //var tag = new Tag {Name = "manel"};
            //UnitOfWork.Session.Save(tag);

            return View();
        }
    }
}

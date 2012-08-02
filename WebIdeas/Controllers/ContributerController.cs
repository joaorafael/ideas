using System.Linq;
using System.Web.Mvc;
using NHibernate.Linq;
using WebIdeas.Infrastructure;
using WebIdeas.Models;

namespace WebIdeas.Controllers
{
    public class ContributerController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var contributer = UnitOfWork.Session.Get<Contributer>(id);
            return View(contributer);
        }
    }
}
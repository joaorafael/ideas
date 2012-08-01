using System.Web.Mvc;

namespace WebIdeas.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Help()
        {
            ViewBag.Message = "ViewBag.Message - Account Help";

            return View();
        }

        public ActionResult LogOn()
        {
            ViewBag.Message = "ViewBag.Message - Account LogOn";

            return View();
        }
    }
}
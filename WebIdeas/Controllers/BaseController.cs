using System.Web.Mvc;
using WebIdeas.Infrastructure;

namespace WebIdeas.Controllers
{
    public abstract class BaseController : Controller
    {
        public UnitOfWork UnitOfWork { get; protected set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UnitOfWork = new UnitOfWork(MvcApplication.Store.SessionFactory);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.IsChildAction)
                return;

            using (UnitOfWork)
            {
                if (filterContext.Exception != null)
                    return;

                if (UnitOfWork != null)
                    UnitOfWork.Commit();
            }
        }
    }
}

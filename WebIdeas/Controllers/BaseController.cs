using System.Web.Mvc;
using NHibernate;
using StructureMap;
using WebIdeas.Infrastructure;

namespace WebIdeas.Controllers
{
    public abstract class BaseController : Controller
    {
        public UnitOfWork UnitOfWork { get; set; }
        protected ISessionFactory SessionFactory = ObjectFactory.GetInstance<ISessionFactory>();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UnitOfWork = new UnitOfWork(SessionFactory);
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

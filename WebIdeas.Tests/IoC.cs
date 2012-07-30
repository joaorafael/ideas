using System.Web.Mvc;
using NHibernate;
using StructureMap;
using WebIdeas.Infrastructure;

namespace WebIdeas.Tests
{
    public static class IoC
    {
        private static readonly NHibernateHelper Nhelper = new NHibernateHelper(@"Server=.\SQLExpress;Database=test;Trusted_Connection=True;", true);
        public static IContainer Initialize()
        {
            
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.AddAllTypesOf<IController>();
                });
                x.For<ISessionFactory>().Use(() => Nhelper.SessionFactory);
            });
            return ObjectFactory.Container;
        }
    }
}
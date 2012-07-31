using System.Web.Mvc;
using NHibernate;
using StructureMap;

namespace WebIdeas.Infrastructure
{
    public static class IoC
    {
        private static readonly NHibernateHelper Nhelper = new NHibernateHelper(Settings.SqlConnectionStringMaster, false);
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
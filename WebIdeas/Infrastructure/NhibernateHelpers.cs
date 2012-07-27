using System;
using System.Data;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace WebIdeas.Infrastructure
{
    public class NHibernateHelper
    {
        private readonly string _connectionString;
        private ISessionFactory _sessionFactory;

        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        public NHibernateHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(_connectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true)) // creates schema
                .BuildSessionFactory();
        }
    }

    public interface IUnitOfWork : IDisposable
    {
        ISession Session { get; }
        void Commit();
        void Rollback();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly ITransaction _transaction;

        public ISession Session { get; private set; }

        public UnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            Session = _sessionFactory.OpenSession();
            Session.FlushMode = FlushMode.Auto;
            _transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Dispose()
        {
            Session.Close();
        }

        public void Commit()
        {
            if (!_transaction.IsActive)
            {
                throw new InvalidOperationException("No active transation");
            }
            _transaction.Commit();
        }

        public void Rollback()
        {
            if (_transaction.IsActive)
            {
                _transaction.Rollback();
            }
        }
    }
}
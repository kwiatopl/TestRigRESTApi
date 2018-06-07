using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRESTApi
{
    public class NHibernateSessionProvider : INHibernateSessionManager
    {
        private readonly string connectionString;
        private ISessionFactory sesssionFactoryCache;


        public NHibernateSessionProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ISession GetCurrentSession()
        {
            if (this.sesssionFactoryCache == null)
            {
                this.sesssionFactoryCache = GetFactory();
            }

            return this.sesssionFactoryCache.OpenSession();
        }

        private ISessionFactory GetFactory()
        {
            var currentConfiguration = new NHibernate.Cfg.Configuration();

            IPersistenceConfigurer dbConfigurer = MsSqlConfiguration.MsSql2012.ConnectionString(this.connectionString).ShowSql();

            return Fluently.Configure().Database(dbConfigurer).Mappings(mc =>
            {
                mc.FluentMappings.Add(typeof(WiperRigMap));
                mc.FluentMappings.Add(typeof(TestsHistoryMap));
            }).BuildSessionFactory();
        }

        public void Dispose()
        {
            this.sesssionFactoryCache.Dispose();
        }
    }

    
}

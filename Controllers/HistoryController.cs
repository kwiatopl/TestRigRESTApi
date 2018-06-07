using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestRESTApi.Controllers
{
    public class HistoryController : ApiController
    {
        public List<TestsHistory> GetHistory()
        {
            var db = new DatabaseService(new NHibernateSessionProvider(ConfigurationManager.ConnectionStrings["WiperDBConfig"].ConnectionString));
            var results = db.GetAll<TestsHistory>().ToList();
            return results;
        }
    }
}

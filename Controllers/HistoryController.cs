using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestRESTApi.Models;

namespace TestRESTApi.Controllers
{
    public class HistoryController : ApiController
    {
        public List<TestsHistoryModel> GetHistory()
        {
            var db = new DatabaseService(new NHibernateSessionProvider(ConfigurationManager.ConnectionStrings["WiperDBConfig"].ConnectionString));
            var results = db.GetAll<TestsHistory>().ToList();
            var resultsList = new List<TestsHistoryModel>();

            foreach(var result in results)
            {
                var item = new TestsHistoryModel()
                {
                    Id = result.Id,
                    TestType = result.TestType,
                    StartDate = result.StartDate.ToString("dd.MM.yyyy HH:mm:ss"),
                    EndDate = result.EndDate.ToString("dd.MM.yyyy HH:mm:ss"),
                    CyclesSet = result.CyclesSet,
                    Countdown = result.Countdown,
                    Errors = result.Errors
                };

                resultsList.Add(item);
            } 

            return resultsList;
        }
    }
}

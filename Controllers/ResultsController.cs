using Newtonsoft.Json;
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
    public class ResultsController : ApiController
    {
        private static DateTime LastProcessedDate = DateTime.Now.AddMinutes(-1);
        public List<WiperRig> GetAllResults()
        {
            var db = new DatabaseService(new NHibernateSessionProvider(ConfigurationManager.ConnectionStrings["WiperDBConfig"].ConnectionString));
            List<WiperRig> results;
            try
            {
                results = db.GetAll<WiperRig>(p => p.TimeStamp > LastProcessedDate).ToList();
                LastProcessedDate = results.Last().TimeStamp;
            }
            catch
            {
                results = null;
            }
            

            return results;
        }
    }
}
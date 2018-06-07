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
    public class ErrorsController : ApiController
    {
        public List<WiperRig> GetErrors()
        {
            var db = new DatabaseService(new NHibernateSessionProvider(ConfigurationManager.ConnectionStrings["WiperDBConfig"].ConnectionString));
            var errors = db.GetAll<WiperRig>(p => p.LeftSensor == true || p.RightSensor == true).ToList();
            return errors;
        }
    }
}

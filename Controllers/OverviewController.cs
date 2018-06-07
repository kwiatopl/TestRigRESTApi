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
    public class OverviewController : ApiController
    {
        public Overview GetOverview()
        {
            var db = new DatabaseService(new NHibernateSessionProvider(ConfigurationManager.ConnectionStrings["WiperDBConfig"].ConnectionString));
            var errorCount = db.GetAll<WiperRig>(p => p.LeftSensor == true || p.RightSensor == true).Count();
            var lastItem = db.GetAll<WiperRig>().OrderByDescending(p => p.TimeStamp).First();
            var firstItem = db.GetAll<WiperRig>().OrderBy(p => p.TimeStamp).First();

            var dateToFinish = firstItem.TimeStamp.AddSeconds(firstItem.Countdown);
            var isError = false ;

            if( errorCount != 0 && errorCount > 0)
            {
                isError = true;
            }

            var returnedObject = new Overview()
            {
                TestType = lastItem.TestType,
                TestStart = firstItem.TimeStamp.ToString("dd.MM.yyyy HH:mm:ss"),
                EstimatedEndDate = dateToFinish.ToString("dd.MM.yyyy HH:mm:ss"),
                CyclesSet = lastItem.CyclesSet,
                Countdown = lastItem.Countdown,
                AmountOfWater = lastItem.AmountOfWater,
                WiperMotorSpeed = lastItem.WiperMotorSpeed,
                WasError = isError,
                ErrorCount = errorCount
            };

            return returnedObject;
        }
    }
}

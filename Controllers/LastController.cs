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
    public class LastController : ApiController
    {
        
        public List<WiperRigModel> GetResults(int id)
        {
            var db = new DatabaseService(new NHibernateSessionProvider(ConfigurationManager.ConnectionStrings["WiperDBConfig"].ConnectionString));
            var results = db.GetAll<WiperRig>().OrderByDescending(p => p.TimeStamp).Take(id).ToList();

            var resultsList = new List<WiperRigModel>();

            foreach (var result in results)
            {
                var item = new WiperRigModel()
                {
                    Id = result.Id,
                    TestType = result.TestType,
                    TimeStamp = result.TimeStamp.ToString("dd.MM.yyyy HH:mm:ss"),
                    DeviceTimeStamp = result.DeviceTimeStamp.ToString("dd.MM.yyyy HH:mm:ss"),
                    CyclesSet = result.CyclesSet,
                    Countdown = result.Countdown,
                    AmountOfWater = result.AmountOfWater,
                    WiperMotorSpeed = result.WiperMotorSpeed,
                    LeftSensor = result.LeftSensor,
                    RightSensor = result.RightSensor
                };

                resultsList.Add(item);
            }

            return resultsList;
        }
    }
}

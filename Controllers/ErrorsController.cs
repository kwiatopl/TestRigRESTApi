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
        public List<WiperRigModel> GetErrors()
        {
            var db = new DatabaseService(new NHibernateSessionProvider(ConfigurationManager.ConnectionStrings["WiperDBConfig"].ConnectionString));
            var errors = db.GetAll<WiperRig>(p => p.LeftSensor == true || p.RightSensor == true).ToList();
            var errorsList = new List<WiperRigModel>();

            foreach (var result in errors)
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

                errorsList.Add(item);
            }

            return errorsList;
        }
    }
}

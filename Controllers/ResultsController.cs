﻿using Newtonsoft.Json;
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
        private static DateTime LastProcessedDate = DateTime.Now.AddSeconds(-1);

        public List<WiperRigModel> GetResults()
        {
            List<WiperRigModel> results = new List<WiperRigModel>();
            try
            {
                var db = new DatabaseService(new NHibernateSessionProvider(ConfigurationManager.ConnectionStrings["WiperDBConfig"].ConnectionString));
                List<WiperRig> semiResults;
                
                semiResults = db.GetAll<WiperRig>(p => p.TimeStamp > LastProcessedDate).ToList();
                LastProcessedDate = semiResults.Last().TimeStamp;

                foreach (var result in semiResults)
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

                    results.Add(item);
                }
            }
            catch
            {
                results = null;
            }
            
            return results;
        }

        public WiperRigModel GetResult(int id)
        {
            var db = new DatabaseService(new NHibernateSessionProvider(ConfigurationManager.ConnectionStrings["WiperDBConfig"].ConnectionString));
            var result = db.GetAll<WiperRig>(p => p.Countdown == id).Last();

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

            return item;
        }
    }
}
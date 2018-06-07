using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestRESTApi.Models;
using System.IO;
using System.Text;
using System.Net.Http.Headers;

namespace TestRESTApi.Controllers
{
    public class ExportController : ApiController
    {
        public HttpResponseMessage GetExport()
        {
            var db = new DatabaseService(new NHibernateSessionProvider(ConfigurationManager.ConnectionStrings["WiperDBConfig"].ConnectionString));
            var results = db.GetAll<WiperRig>().ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Id;Test Type;TimeStamp;DeviceTimeStamp;Cycles Set;Countdown;Amount of Water;Wiper Motor Speed;Left Sensor; Right Sensor;{0}", Environment.NewLine);
            foreach (var result in results)
            {
                sb.AppendFormat("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}", result.Id, result.TestType, result.TimeStamp.ToString("yyyy.MM.dd HH:mm:ss"), result.DeviceTimeStamp.ToString("yyyy.MM.dd HH:mm:ss"), result.CyclesSet, result.Countdown, result.AmountOfWater, result.WiperMotorSpeed, result.LeftSensor, result.RightSensor, Environment.NewLine);
            }
            var resultString = sb.ToString();

            var zip = new ZipPacker();
            var stream = new System.IO.MemoryStream(zip.Pack(resultString, Encoding.ASCII));
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
            message.Content = new StreamContent(stream);
            message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            message.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachement");
            message.Content.Headers.ContentDisposition.FileName = "Results.zip";

            return message;
        }
    }
}

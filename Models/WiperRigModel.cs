using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestRESTApi.Models
{
    public class WiperRigModel
    {
        public virtual int Id { get; set; }
        public virtual string TestType { get; set; }
        public virtual string TimeStamp { get; set; }
        public virtual string DeviceTimeStamp { get; set; }
        public virtual int CyclesSet { get; set; }
        public virtual int Countdown { get; set; }
        public virtual int AmountOfWater { get; set; }
        public virtual int WiperMotorSpeed { get; set; }
        public virtual bool LeftSensor { get; set; }
        public virtual bool RightSensor { get; set; }
    }
}
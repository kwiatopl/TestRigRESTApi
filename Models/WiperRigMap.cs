using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRESTApi.Models;

namespace TestRESTApi
{
    public sealed class WiperRigMap : ClassMap<WiperRig>
    {

        public WiperRigMap()
        {
            this.Table("WiperTest");

            this.Id(x => x.Id, "Id").Not.Nullable().GeneratedBy.Increment();
            this.Map(x => x.AmountOfWater).Nullable();
            this.Map(x => x.Countdown).Nullable();
            this.Map(x => x.CyclesSet).Nullable();
            this.Map(x => x.DeviceTimeStamp).Nullable();
            this.Map(x => x.LeftSensor).Nullable();
            this.Map(x => x.RightSensor).Nullable();
            this.Map(x => x.TestType).Nullable();
            this.Map(x => x.TimeStamp).Nullable();
            this.Map(x => x.WiperMotorSpeed).Nullable();

        }
    }
}

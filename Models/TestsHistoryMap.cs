using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRESTApi
{
    public sealed class TestsHistoryMap : ClassMap<TestsHistory>
    {

        public TestsHistoryMap()
        {
            this.Table("TestsHistory");

            this.Id(x => x.Id, "Id").Not.Nullable().GeneratedBy.Increment();
            this.Map(x => x.Countdown).Nullable();
            this.Map(x => x.CyclesSet).Nullable();
            this.Map(x => x.StartDate).Nullable();
            this.Map(x => x.EndDate).Nullable();
            this.Map(x => x.Errors).Nullable();
            this.Map(x => x.TestType).Nullable();

        }
    }
}

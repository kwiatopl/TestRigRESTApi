using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRESTApi
{
    public class TestsHistory
    {
        public virtual int Id { get; set; }
        public virtual string TestType { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual int CyclesSet { get; set; }
        public virtual int Countdown { get; set; }
        public virtual int Errors { get; set; }
    }
}

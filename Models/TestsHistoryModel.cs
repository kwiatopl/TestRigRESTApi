using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestRESTApi.Models
{
    public class TestsHistoryModel
    {
        public virtual int Id { get; set; }
        public virtual string TestType { get; set; }
        public virtual string StartDate { get; set; }
        public virtual string EndDate { get; set; }
        public virtual int CyclesSet { get; set; }
        public virtual int Countdown { get; set; }
        public virtual int Errors { get; set; }
    }
}
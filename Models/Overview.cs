﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestRESTApi.Models
{
    public class Overview
    {
        public string TestType;
        public string TestStart;
        public string EstimatedEndDate;
        public int CyclesSet;
        public int Countdown;
        public int AmountOfWater;
        public int WiperMotorSpeed;
        public int ErrorCount;
        public bool WasError;
    }
}
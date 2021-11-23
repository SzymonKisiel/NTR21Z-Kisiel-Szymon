using System;
using System.Collections.Generic;

namespace TRS.Models
{
    public class AcceptedTime
    {
        public string code { get; set; }
        public int time { get; set; }

        public AcceptedTime(string code, int time)
        {
            this.code = code;
            this.time = time;
        }
    }
}
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace TRS.Models
{
    public class AcceptedTime
    {
        public int AcceptedTimeID { get; set; }
        public int Time { get; set; }
        public virtual Report Report { get; set; }
        public virtual Project Project { get; set; }

        // [Timestamp]
        public DateTime Timestamp { get; set; }
    }
}
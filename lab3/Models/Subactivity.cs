using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace TRS.Models
{
    public class Subactivity
    {
        public int SubactivityID { get; set; }
        public string Name { get; set; }
        public virtual Project Project { get; set; }

        // [Timestamp]
        public DateTime Timestamp { get; set; }
    }
}
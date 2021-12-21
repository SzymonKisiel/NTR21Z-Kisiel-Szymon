using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace TRS.Models
{
    public class Subactivity
    {
        public int SubactivityID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; } // foreign key
        public virtual Project Project { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
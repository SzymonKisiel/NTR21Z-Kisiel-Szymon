using System.Collections.Generic;
using System;

namespace TRS.Models
{
    public class Subactivity
    {
        public int SubactivityID { get; set; }
        public string Name { get; set; }
        public virtual Project Project { get; set; }
    }
}
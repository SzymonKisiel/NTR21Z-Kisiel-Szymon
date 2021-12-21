using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace TRS.Models
{
    public class Project
    {
        public string Code { get; set; }
        public string Manager { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public bool Active { get; set; } = true;
        public virtual List<Subactivity> Subactivities { get; set; } = new List<Subactivity>();
        public virtual ICollection<ActivityEntry> Activities { get; set; }
        public virtual ICollection<AcceptedTime> AcceptedTimes { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
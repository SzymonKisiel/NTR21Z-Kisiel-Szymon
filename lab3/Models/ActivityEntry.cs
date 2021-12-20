using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace TRS.Models
{
    public class ActivityEntry
    {
        public int ActivityEntryID { get; set; }

        public virtual Report Report { get; set; }

        public string Code { get; set; }
        public virtual Project Project { get; set; }

        public DateTime Date { get; set; }
        public string Subcode { get; set; } = "";
        public int Time { get; set; }
        public string Description { get; set; }

        // [Timestamp]
        public DateTime Timestamp { get; set; }
    }
}
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace TRS.Models
{
    public class Report
    {
        public int ReportID { get; set; }
        public string Username { get; set; }
        public DateTime Month { get; set; }
        public bool Frozen { get; set; } = false;
        public virtual ICollection<ActivityEntry> Activities { get; set; }
        public virtual ICollection<AcceptedTime> Accepted { get; set; }

        public DateTime Timestamp { get; set; }

        public int GetReportedTimeSum()
        {
            var reportedTimeSum = 0;
            foreach (var activity in Activities)
            {
                reportedTimeSum += activity.Time;
            }
            return reportedTimeSum;
        }
    }
}
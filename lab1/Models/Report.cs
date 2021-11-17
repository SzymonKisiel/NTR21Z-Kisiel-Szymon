using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace TRS.Models
{
    public class Report
    {
        //?
        [JsonIgnore]
        public string username { get; set; }
        [JsonIgnore]
        public DateTime month { get; set; }
        public bool frozen { get; set; }
        public List<ActivityEntry> entries { get; set; }
        public List<AcceptedTime> accepted { get; set; }

        public void AddActivity(ActivityEntry activity)
        {
            entries.Add(activity);
        }

        public void ToDayReport(DateTime date)
        {
            List<ActivityEntry> dayEntries = new List<ActivityEntry>();
            foreach (var entry in entries)
            {
                if ((entry.date.Year, entry.date.Month, entry.date.Day) == (date.Year, date.Month, date.Day))
                {
                    dayEntries.Add(entry);
                }
            }
            this.entries = dayEntries;
        }
    }
}
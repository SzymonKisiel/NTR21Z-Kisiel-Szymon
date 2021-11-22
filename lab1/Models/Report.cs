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
        public bool frozen { get; set; } = false;
        public List<ActivityEntry> entries { get; set; } = new List<ActivityEntry>();
        public List<AcceptedTime> accepted { get; set; } = new List<AcceptedTime>();

        private int _reportedTimeSum = 0;
        [JsonIgnore]
        public int reportedTimeSum
        {
            get
            {
                _reportedTimeSum = 0;
                foreach (var entry in entries)
                {
                    _reportedTimeSum += entry.time;
                }
                return _reportedTimeSum;
            }
            private set
            {
                _reportedTimeSum = value;
            }
        }

        public ActivityEntry GetActivity(string projectCode, DateTime date)
        {
            return entries.Find(entry =>
                entry.code == projectCode && entry.date == date
            );
        }

        public void AddActivity(ActivityEntry activity)
        {
            entries.Add(activity);
        }

        public void DeleteActivity(string projectCode, DateTime date)
        {
            int index = entries.FindIndex(entry =>
                entry.code == projectCode && entry.date == date
            );
            entries.RemoveAt(index);
        }

        public void UpdateActivity(string projectCode, DateTime date, ActivityEntry newActivity)
        {
            int index = entries.FindIndex(entry =>
                entry.code == projectCode && entry.date == date
            );
            if (index != -1)
                entries[index] = newActivity;
        }

        public void CloseMonth()
        {
            this.frozen = true;
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

        public void ToProjectReport(string projectCode)
        {
            List<ActivityEntry> projectEntries = new List<ActivityEntry>();
            foreach (var entry in entries)
            {
                if (entry.code == projectCode)
                {
                    projectEntries.Add(entry);
                }
            }
            this.entries = projectEntries;
        }

        public string GetUser()
        {
            return username;
        }

        // public void ToManagerReport(string manager)
        // {
        //     List<ActivityEntry> managerEntries = new List<ActivityEntry>();
        //     foreach (var entry in entries)
        //     {
        //         if (entry. == projectCode)
        //         {
        //             projectEntries.Add(entry);
        //         }
        //     }
        //     this.entries = managerEntries;
        // }
    }
}
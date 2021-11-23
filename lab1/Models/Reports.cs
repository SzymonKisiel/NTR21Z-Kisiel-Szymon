using System;
using System.Collections.Generic;

using System.Text.Json;
using System.IO;

namespace TRS.Models
{
    public class Reports
    {
        public List<Report> reports = new List<Report>();
        public List<Report> GetAll()
        {
            return reports;
        }
        public void AddReport(Report report)
        {
            reports.Add(report);
        }

        public ActivityEntry GetActivity(string projectCode, DateTime date)
        {
            if (reports.Count > 1)
            {
                throw new Exception();
            }
            foreach (var report in reports)
            {
                return report.GetActivity(projectCode, date);
            }
            return null;
        }

        public void AddActivity(ActivityEntry activity)
        {
            if (reports.Count > 1)
            {
                throw new Exception();
            }
            foreach (var report in reports)
            {
                report.AddActivity(activity);
            }
        }
        public void DeleteActivity(string projectCode, DateTime date)
        {
            if (reports.Count > 1)
            {
                throw new Exception();
            }
            foreach (var report in reports)
            {
                report.DeleteActivity(projectCode, date);
            }
        }

        public void UpdateActivity(string projectCode, DateTime date, ActivityEntry newActivity)
        {
            if (reports.Count > 1)
            {
                throw new Exception();
            }
            foreach (var report in reports)
            {
                report.UpdateActivity(projectCode, date, newActivity);
            }
        }

        public void CloseMonth()
        {
            if (reports.Count > 1)
            {
                throw new Exception();
            }
            foreach (var report in reports)
            {
                report.CloseMonth();
            }
        }
        
        public Reports ToDayReports(DateTime date)
        {
            foreach (var report in reports)
            {
                report.ToDayReport(date);
            }
            return this;
        }
        public Reports ToProjectReports(string projectCode)
        {
            foreach (var report in reports)
            {
                report.ToProjectReport(projectCode);
            }
            return this;
        }
        public bool IsFrozen()
        {
            if (reports.Count == 0)
            {
                return false;
            }
            if (reports.Count > 1)
            {
                throw new Exception();
            }
            foreach (var report in reports)
            {
                return report.frozen;
            }
            return true;
        }
        public int Count()
        {
            return reports.Count;
        }

        public List<string> GetUsers()
        {
            List<string> users = new List<string>();
            foreach (var report in reports)
            {
                users.Add(report.GetUser());
            }
            return users;
        }

        public int GetAcceptedTime(string projectCode)
        {
            if (reports.Count > 1)
            {
                throw new Exception();
            }
            foreach (var report in reports)
            {
                return report.GetAcceptedTime(projectCode);
            }
            return 0;
        }

        public void SetAcceptedTime(string projectCode, int newAcceptedTime)
        {
            if (reports.Count > 1)
            {
                throw new Exception();
            }
            foreach (var report in reports)
            {
                report.SetAcceptedTime(projectCode, newAcceptedTime);
            }
        }
    }
}
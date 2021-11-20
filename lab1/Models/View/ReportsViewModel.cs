using System;
using System.Collections.Generic;

using System.Text.Json;
using System.IO;

namespace TRS.Models
{
    public class ReportsViewModel
    {
        public readonly string directory = "Data/";
        private Func<string, string, string> removeSubstring =
            (value, substring) =>
            value.Remove(value.IndexOf(substring), substring.Length);

        private Reports LoadFromFiles(string searchPattern)
        {
            //Console.WriteLine("Reports.loadFromFiles()");
            var reports = new Reports();

            foreach (string filename in Directory.GetFiles(directory, searchPattern))
            {
                // filename to username and month of report
                string temp = removeSubstring(filename, ".json");
                temp = removeSubstring(temp, directory);

                string[] substrings = temp.Split('-', 2);

                string username = substrings[0];
                DateTime dateMonth = DateTime.Parse(substrings[1]);


                string jsonString = System.IO.File.ReadAllText(filename);
                Report report = JsonSerializer.Deserialize<Report>(jsonString);
                report.username = username;
                report.month = dateMonth;

                reports.AddReport(report);
            }
            return reports;
        }

        private void SaveToFile(Reports reports)
        {
            foreach (var report in reports.GetAll())
            {
                string filename = $"{directory}{report.username}-{report.month.ToString("yyyy-MM")}.json";
                Console.WriteLine(filename);

                string jsonString = JsonSerializer.Serialize<Report>(report);
                System.IO.File.WriteAllText(filename, jsonString);
            }
        }

        private void CreateFile(string username, DateTime month)
        {
            string filename = $"{directory}{username}-{month.ToString("yyyy-MM")}.json";
            System.IO.File.Create(filename).Close();
            string jsonString = JsonSerializer.Serialize<Report>(new Report());
            System.IO.File.WriteAllText(filename, jsonString);
        }

        public Reports GetMonthReports(DateTime date)
        {
            return LoadFromFiles($"*-{date.Year}-{date.Month}.json");
        }

        public Reports GetMonthReports(string username, DateTime date)
        {
            return LoadFromFiles($"{username}-{date.Year}-{date.Month}.json");
        }

        public Reports GetMonthReports(DateTime date, string projectCode)
        {
            var reports = GetMonthReports(date);
            return reports.ToProjectReports(projectCode);
        }

        public Reports GetMonthReports(string username, DateTime date, string projectCode)
        {
            var reports = GetMonthReports(username, date);
            return reports.ToProjectReports(projectCode);
        }

        public Reports GetDayReports(DateTime date)
        {
            var reports = GetMonthReports(date);
            return reports.ToDayReports(date);
        }

        public Reports GetDayReports(string username, DateTime date)
        {
            var reports = GetMonthReports(username, date);
            return reports.ToDayReports(date);
        }

        public void AddActivity(ActivityEntry activity, string username)
        {
            var reports = GetMonthReports(username, activity.date);
            if (reports.Count() == 0)
            {
                CreateFile(username, activity.date);
                reports = GetMonthReports(username, activity.date);
            }
            reports.AddActivity(activity);
            SaveToFile(reports);
        }

        public void DeleteActivity(string projectCode, string username, DateTime date)
        {
            var reports = GetMonthReports(username, date);
            reports.DeleteActivity(projectCode, date);
            SaveToFile(reports);
        }

        public void UpdateActivity(string projectCode, string username, DateTime date, ActivityEntry newActivity)
        {
            var reports = GetMonthReports(username, date);
            reports.DeleteActivity(projectCode, date);
            SaveToFile(reports);
        }

        public void EditActivity()
        {
            // TODO
            ;
        }
    }
}
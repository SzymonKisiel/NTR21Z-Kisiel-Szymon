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

        // public Reports ToManagerReports(string manager)
        // {
        //     foreach (var report in reports)
        //     {
        //         report.ToManagerReport(manager);
        //     }
        //     return this;
        // }

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
    }
}

// using System;
// using System.Collections.Generic;

// using System.Text.Json;
// using System.IO;

// namespace TRS.Models
// {
//     public class Reports
//     {
//         public List<Report> reports;
//         public readonly string directory = "Data/";

//         Func<string, string, string> removeSubstring =
//             (value, substring) =>
//             value.Remove(value.IndexOf(substring), substring.Length);

//         private void LoadFromFiles(string searchPattern)
//         {
//             Console.WriteLine("Reports.loadFromFiles()");
//             var reports = new List<Report>();

//             foreach (string filename in Directory.GetFiles(directory, searchPattern))
//             {
//                 // filename to username and month of report
//                 string temp = removeSubstring(filename, ".json");
//                 temp = removeSubstring(temp, directory);

//                 string[] substrings = temp.Split('-', 2);

//                 string username = substrings[0];
//                 DateTime dateMonth = DateTime.Parse(substrings[1]);


//                 string jsonString = System.IO.File.ReadAllText(filename);
//                 Report report = JsonSerializer.Deserialize<Report>(jsonString);
//                 report.username = username;
//                 report.month = dateMonth;

//                 reports.Add(report);
//             }

//             this.reports = reports;
//         }


//         public void LoadFromFiles(int year, int month)
//         {
//             LoadFromFiles($"*-{year}-{month}.json");
//         }

//         public void LoadFromFiles(string username, int year, int month)
//         {
//             LoadFromFiles($"{username}-{year}-{month}.json");
//         }

//         public void SaveToFiles()
//         {
//             Console.WriteLine("Reports.saveToFiles()");
//             DateTime testDate = new DateTime(2021, 8, 1);
//             var testString = testDate.ToString("yyyy-MM");

//             foreach (var report in this.reports)
//             {
//                 string filename = $"{directory}{report.username}-{report.month.ToString("yyyy-MM")}.json";
//                 // string filename = directory;
//                 // filename += report.username;
//                 // filename += "-";
//                 // filename += report.month.ToString("yyyy-MM");
//                 // filename += ".json";
//                 Console.WriteLine(filename);

//                 string jsonString = JsonSerializer.Serialize<Report>(report);
//                 System.IO.File.WriteAllText(filename, jsonString);
//             }
//         }

//         public void LoadDayActivities(int year, int month, int day) {
//             LoadFromFiles(year, month);
//             foreach (var report in reports) {
//                 report.ToDayReport(year, month, day);
//             }
//         }

//         public void LoadDayActivities(string username, int year, int month, int day) {
//             LoadFromFiles(username, year, month);
//             foreach (var report in reports) {
//                 report.ToDayReport(year, month, day);
//             }
//         }

//         public void AddActivity() {

//         }

//         public void RemoveActivity() {

//         }

//         public void AddProject() {

//         }
//     }
// }
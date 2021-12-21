using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace TRS.Models
{
    public class TRSViewModel
    {
        public void RemoveAllData()
        {
            using (var context = new TRSContext())
            {
                // Creates the database if not exists
                context.Database.Migrate();

                context.Project.RemoveRange(context.Project);
                context.Report.RemoveRange(context.Report);
                context.AcceptedTime.RemoveRange(context.AcceptedTime);
                context.ActivityEntry.RemoveRange(context.ActivityEntry);
                context.Subactivity.RemoveRange(context.Subactivity);

                context.SaveChanges();
            }
        }

        public void InsertExampleData()
        {
            using (var context = new TRSContext())
            {
                // Creates the database if not exists
                context.Database.Migrate();

                var project = new Project
                {
                    Code = "BETA",
                    Manager = "nowak",
                    Name = "Project Beta",
                    Budget = 1000
                };
                context.Project.Add(project);

                var subactivity1 = new Subactivity
                {
                    Name = "coding",
                    Project = project
                };
                var subactivity2 = new Subactivity
                {
                    Name = "other",
                    Project = project
                };
                context.Subactivity.Add(subactivity1);
                context.Subactivity.Add(subactivity2);

                var report = new Report
                {
                    Username = "kowalski",
                    Month = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
                };
                context.Report.Add(report);

                context.ActivityEntry.Add(new ActivityEntry
                {
                    Date = DateTime.Now.AddDays(-1),
                    Subcode = "other",
                    Time = 15,
                    Description = "picie kawy",
                    Report = report,
                    Project = project
                });

                context.ActivityEntry.Add(new ActivityEntry
                {
                    Date = DateTime.Now,
                    Subcode = "coding",
                    Time = 100,
                    Description = "debugging",
                    Report = report,
                    Project = project
                });

                context.AcceptedTime.Add(new AcceptedTime
                {
                    Time = 90,
                    Project = project,
                    Report = report
                });


                context.SaveChanges(); // Saves changes
            }
        }

        public List<Project> GetProjects()
        {
            List<Project> projects;
            using (var context = new TRSContext())
            {
                projects = context.Project.Include(p => p.Subactivities).ToList();
            }
            return projects;
        }

        public List<Project> GetProjects(string manager)
        {
            List<Project> projects;
            using (var context = new TRSContext())
            {
                projects = context.Project.Where(p => p.Manager == manager).Include(p => p.Subactivities).ToList();
            }
            return projects;
        }

        public List<string> GetSubactivities(string code)
        {
            List<string> result;
            using (var context = new TRSContext())
            {
                var query = from project in context.Project
                            where project.Code == code
                            join subactivity in context.Subactivity on project equals subactivity.Project
                            select subactivity.Name;
                result = query.ToList();
            }
            return result;
        }

        public void AddProject(Project project)
        {
            using (var context = new TRSContext())
            {
                // Creates the database if not exists 
                context.Database.Migrate();
                context.Project.Add(project);
                context.SaveChanges();
            }
        }

        public void CloseProject(string projectCode)
        {
            using (var context = new TRSContext())
            {
                // Creates the database if not exists 
                context.Database.Migrate();

                var query = from p in context.Project
                            where p.Code == projectCode
                            select p;

                var project = query.Single();
                project.Active = false;

                context.SaveChanges();
            }

        }

        public bool IsActive(string projectCode)
        {
            bool isActive = false;
            using (var context = new TRSContext())
            {
                var query = from p in context.Project
                            where p.Code == projectCode
                            select p;

                var project = query.SingleOrDefault();
                if (project != null)
                    isActive = project.Active;
            }
            return isActive;
        }

        public int GetBudget(string projectCode)
        {
            int budget = 0;
            using (var context = new TRSContext())
            {
                var query = from p in context.Project
                            where p.Code == projectCode
                            select p;

                var project = query.Single();
                budget = project.Budget;
            }
            return budget;
        }

        public List<Report> GetAllReports()
        {
            List<Report> reports;
            using (var context = new TRSContext())
            {
                reports = context.Report.Include(r => r.Activities).ToList();
            }
            return reports;
        }

        public List<Report> GetMonthReports(DateTime date)
        {
            List<Report> reports;
            using (var context = new TRSContext())
            {
                var query = from report in context.Report
                            where report.Month.Year == date.Year && report.Month.Month == date.Month
                            select report;
                reports = query.Include(r => r.Activities).ToList();
            }
            return reports;
        }

        public List<Report> GetMonthReports(string username, DateTime date)
        {
            List<Report> reports;
            using (var context = new TRSContext())
            {
                var query = from report in context.Report
                            where report.Month.Year == date.Year && report.Month.Month == date.Month && report.Username == username
                            select report;
                reports = query.Include(r => r.Activities).ToList();
            }
            return reports;
        }

        public List<Report> GetMonthReports(DateTime date, string projectCode)
        {
            List<Report> reports;
            using (var context = new TRSContext())
            {
                reports = context.Report
                    .Where(report => report.Month.Year == date.Year && report.Month.Month == date.Month)
                    .Where(report => report.Activities.Any(activity => activity.Code == projectCode))
                    .Select(report => new Report {
                        ReportID = report.ReportID,
                        Username = report.Username,
                        Month = report.Month,
                        Frozen = report.Frozen,
                        Activities = report.Activities.Where(activity => activity.Code == projectCode).ToList()
                    })
                    .ToList();
            }
            return reports;
        }

        public List<Report> GetMonthReports(string username, DateTime date, string projectCode)
        {
            List<Report> reports;
            using (var context = new TRSContext())
            {
                reports = context.Report
                    .Where(report => report.Month.Year == date.Year && report.Month.Month == date.Month)
                    .Where(report => report.Username == username)
                    .Where(report => report.Activities.Any(activity => activity.Code == projectCode))
                    .Select(report => new Report {
                        ReportID = report.ReportID,
                        Username = report.Username,
                        Month = report.Month,
                        Frozen = report.Frozen,
                        Activities = report.Activities.Where(activity => activity.Code == projectCode).ToList()
                    })
                    .ToList();
            }
            return reports;
        }

        public List<Report> GetDayReports(DateTime date)
        {
            List<Report> reports;
            using (var context = new TRSContext())
            {
                reports = context.Report
                    .Where(report => report.Activities.Any(activity => activity.Date.Year == date.Year && activity.Date.Month == date.Month && activity.Date.Day == date.Day))
                    .Select(report => new Report {
                        ReportID = report.ReportID,
                        Username = report.Username,
                        Month = report.Month,
                        Frozen = report.Frozen,
                        Activities = report.Activities.Where(activity => activity.Date.Year == date.Year && activity.Date.Month == date.Month && activity.Date.Day == date.Day).ToList()
                    })
                    .ToList();
            }
            return reports;
        }

        public List<Report> GetDayReports(string username, DateTime date)
        {
            List<Report> reports;
            using (var context = new TRSContext())
            {
                reports = context.Report
                    .Where(report => report.Username == username)
                    .Where(report => report.Activities.Any(activity => activity.Date.Year == date.Year && activity.Date.Month == date.Month && activity.Date.Day == date.Day))
                    .Select(report => new Report {
                        ReportID = report.ReportID,
                        Username = report.Username,
                        Month = report.Month,
                        Frozen = report.Frozen,
                        Activities = report.Activities.Where(activity => activity.Date.Year == date.Year && activity.Date.Month == date.Month && activity.Date.Day == date.Day).ToList()
                    })
                    .ToList();
            }
            return reports;
        }

        public void AddActivity(ActivityEntry activity, string username)
        {
            using (var context = new TRSContext())
            {
                //Creates the database if not exists 
                context.Database.Migrate();
                
                var report = context.Report.FirstOrDefault(r => r.Month.Year == activity.Date.Year && r.Month.Month == activity.Date.Month && r.Username == username);
                if (report == null)
                {
                    // create report if not exists
                    report = new Report {
                        Username = username,
                        Month = new DateTime(activity.Date.Year, activity.Date.Month, 1)
                    };
                    context.Report.Add(report);
                    context.SaveChanges();
                }
                else {
                    // check if report editable
                    if (!IsReportEditable(username, activity.Date, activity.Code))
                        return;
                }

                // create activity
                activity.Report = report;
                context.ActivityEntry.Add(activity);

                context.SaveChanges();
            }
        }

        public void DeleteActivity(int activityID)
        {
            using (var context = new TRSContext())
            {
                //Creates the database if not exists 
                context.Database.Migrate();
                // check if report editable
                // if (!IsReportEditable(username, date, projectCode))
                //     return;
                // delete activity and add to reports and project
                var query = from a in context.ActivityEntry
                            where a.ActivityEntryID == activityID
                            select a;
                var activity = query.Single();
                context.Remove(activity);

                context.SaveChanges();
            }
        }

        public void UpdateActivity(int activityID, ActivityEntry newActivity)
        {
            using (var context = new TRSContext())
            {
                //Creates the database if not exists 
                context.Database.Migrate();
                // check if report editable
                // if (!IsReportEditable(username, date, projectCode))
                //     return;
                context.Update(newActivity);

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void CloseMonth(string username, DateTime month)
        {
            using (var context = new TRSContext())
            {
                //Creates the database if not exists 
                context.Database.Migrate();

                var query = from r in context.Report
                            where r.Username == username && r.Month.Year == month.Year && r.Month.Month == month.Month
                            select r;

                var report = query.Single();
                report.Frozen = true;

                context.SaveChanges();
            }
        }

        public bool IsMonthClosed(string username, DateTime month)
        {
            bool isFrozen = false;
            using (var context = new TRSContext())
            {
                var query = from r in context.Report
                            where r.Username == username && r.Month.Year == month.Year && r.Month.Month == month.Month
                            select r;
                var report = query.SingleOrDefault();
                if (report != null)
                    isFrozen = report.Frozen;
            }

            return isFrozen;
        }

        public List<string> GetUsers(string code, DateTime month)
        {
            List<string> result;
            using (var context = new TRSContext())
            {
                var query = from activity in context.ActivityEntry
                            join project in context.Project on activity.Project equals project
                            where project.Code == code
                            join report in context.Report on activity.Report equals report
                            where report.Month.Year == month.Year && report.Month.Month == month.Month
                            select report.Username;

                result = query.Distinct().ToList(); // list of unique users
            }
            return result;
        }

        public int GetAcceptedTime(string projectCode, string username, DateTime month)
        {
            int result = 0;
            using (var context = new TRSContext())
            {
                var query = from accepted in context.AcceptedTime
                            join report in context.Report on accepted.Report equals report
                            where report.Username == username && report.Month.Year == month.Year && report.Month.Month == month.Month
                            join project in context.Project on accepted.Project equals project
                            where project.Code == projectCode
                            select accepted;

                var acceptedTime = query.SingleOrDefault();
                if (acceptedTime != null)
                {
                    result = acceptedTime.Time;
                }
            }
            return result;
        }

        public void SetAcceptedTime(string projectCode, string username, DateTime month, int newAcceptedTime)
        {
            using (var context = new TRSContext())
            {
                //Creates the database if not exists 
                context.Database.Migrate();

                var query = from accepted in context.AcceptedTime
                            join report in context.Report on accepted.Report equals report
                            where report.Username == username && report.Month.Year == month.Year && report.Month.Month == month.Month
                            join project in context.Project on accepted.Project equals project
                            where project.Code == projectCode
                            select accepted;

                var acc = query.SingleOrDefault();
                if (acc != null)
                {
                    acc.Time = newAcceptedTime;
                }
                else
                {
                    context.AcceptedTime.Add(new AcceptedTime {
                        Time = newAcceptedTime,
                        Code = projectCode,
                        Report = context.Report
                            .Where(report => 
                                report.Username == username && report.Month.Year == month.Year && report.Month.Month == month.Month
                            )
                            .Single()
                    });
                }

                context.SaveChanges();

            }
        }

        public bool IsReportEditable(string username, DateTime month, string code)
        {
            return IsActive(code) && !IsMonthClosed(username, month);
        }

        public int GetAcceptedTimeSum(string projectCode)
        {
            int result = 0;
            using (var context = new TRSContext())
            {
                var query = from accepted in context.AcceptedTime
                            join report in context.Report on accepted.Report equals report
                            join project in context.Project on accepted.Project equals project
                            where project.Code == projectCode
                            select accepted;

                foreach (var accepted in query.ToList())
                {
                    result += accepted.Time;
                }
            }
            return result;
        }

        public int GetAcceptedTimeSum(string projectCode, DateTime month)
        {
            int result = 0;
            using (var context = new TRSContext())
            {
                var query = from accepted in context.AcceptedTime
                            join report in context.Report on accepted.Report equals report
                            where report.Month.Year == month.Year && report.Month.Month == month.Month
                            join project in context.Project on accepted.Project equals project
                            where project.Code == projectCode
                            select accepted;

                foreach (var accepted in query.ToList())
                {
                    result += accepted.Time;
                }
            }
            return result;
        }

        public ActivityEntry GetActivity(int activityID)
        {
            using (var context = new TRSContext())
            {
                return context.ActivityEntry
                    .Where(a => a.ActivityEntryID == activityID)
                    .SingleOrDefault();
            }
        } 
    }
}
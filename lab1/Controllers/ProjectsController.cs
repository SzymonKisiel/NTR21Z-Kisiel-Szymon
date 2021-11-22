using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TRS.Models;

using System.Text.Json;
using Microsoft.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Dynamic;

namespace TRS.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ReportsViewModel reportsModel = new ReportsViewModel();
        public ProjectsViewModel projectsModel = new ProjectsViewModel();
        public string username
        {
            get
            {
                return HttpContext.Session.GetString("username");
            }
            set
            {
                HttpContext.Session.SetString("username", value);
            }
        }

        public ProjectsController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Projects()
        {
            return View(projectsModel.GetProjects());
        }

        public IActionResult NewProject()
        {
            if (this.username == null)
                return RedirectToAction("Index", "Login");
            ViewData["username"] = this.username;
            return View(new Project());
        }

        [HttpPost]
        public IActionResult NewProjectAddSubactivity(Project project)
        {
            if (this.username == null)
                return RedirectToAction("Index", "Login");
            ViewData["username"] = this.username;
            return View("NewProject", project);
        }

        [HttpPost]
        public IActionResult NewProject(Project project)
        {
            if (this.username == null)
                return RedirectToAction("Index", "Login");
            var username = this.username;
            project.manager = username;
            projectsModel.AddProject(project);

            return RedirectToAction("Projects");
        }

        public IActionResult NewActivity(string code)
        {
            var newActivity = new ActivityEntry();
            newActivity.code = code;

            DateTime month = (DateTime)TempData["Month"];
            var firstDay = new DateTime(month.Year, month.Month, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);

            ViewData["Code"] = code;
            ViewData["Subactivities"] = projectsModel.GetSubactivities(code);

            ViewData["FirstDay"] = firstDay.ToString("yyyy-MM-dd");
            ViewData["LastDay"] = lastDay.ToString("yyyy-MM-dd");

            return View(newActivity);
        }
        [HttpPost]
        public IActionResult NewActivity(ActivityEntry activity, string code)
        {
            var test = activity;
            reportsModel.AddActivity(activity, this.username);

            return RedirectToAction("Details", new { code = code });
        }

        public IActionResult Details(string code)
        {
            var date = DateTime.Now;
            ViewBag.Reports = reportsModel.GetMonthReports(this.username, date, code);
            ViewBag.ProjectCode = code;
            TempData["Month"] = date;
            return View(new DateViewModel());

            // dynamic model = new ExpandoObject();
            // var date = DateTime.Now;

            // model.Date = date;
            // model.Reports = reportsModel.GetMonthReports(this.username, date, code);
            // model.ProjectCode = code;

            // return View(model);
        }
        [HttpPost]
        public IActionResult Details(DateViewModel model, string code)
        {
            var date = model.date;
            ViewBag.Reports = reportsModel.GetMonthReports(this.username, date, code);
            ViewBag.ProjectCode = code;
            TempData["Month"] = date;
            return View(model);
        }

        public IActionResult CloseMonth(string code)
        {
            DateTime month = (DateTime)TempData["Month"];
            Console.WriteLine($"Close month {month} {code}");
            reportsModel.CloseMonth(this.username, month);
            return RedirectToAction("Details", new { code = code });
        }

        public IActionResult DeleteActivity(string date, string code)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);
            reportsModel.DeleteActivity(code, this.username, dateTime);

            return RedirectToAction("Details", new { code = code });
        }

        public IActionResult UpdateActivity(string date, string code)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);
            var newActivity = reportsModel.GetActivity(code, this.username, dateTime);

            DateTime month = dateTime;
            var firstDay = new DateTime(month.Year, month.Month, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);

            ViewData["Code"] = code;
            ViewData["Subactivities"] = projectsModel.GetSubactivities(code);

            ViewData["FirstDay"] = firstDay.ToString("yyyy-MM-dd");
            ViewData["LastDay"] = lastDay.ToString("yyyy-MM-dd");
            ViewData["DefaultDay"] = dateTime.ToString("yyyy-MM-dd");

            EditViewModel model = new EditViewModel();
            model.activity = newActivity;
            model.oldDate = dateTime;
            model.oldCode = code;

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateActivity(EditViewModel model)
        {
            DateTime date = model.oldDate;
            string code = model.oldCode;
            ActivityEntry newActivity = model.activity;
            //string username = model.username;
            
            reportsModel.UpdateActivity(code, this.username, date, newActivity);
            return RedirectToAction("Projects");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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
            var username = this.username;
            project.manager = username;
            projectsModel.AddProject(project);

            return RedirectToAction("Projects");
        }

        public IActionResult NewActivity(string id)
        {
            var newActivity = new ActivityEntry();
            newActivity.code = id;

            DateTime month = (DateTime)TempData["Month"];
            var firstDay = new DateTime(month.Year, month.Month, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);

            ViewData["Code"] = id;
            ViewData["Subactivities"] = projectsModel.GetSubactivities(id);

            ViewData["FirstDay"] = firstDay.ToString("yyyy-MM-dd");
            ViewData["LastDay"] = lastDay.ToString("yyyy-MM-dd");

            return View(newActivity);
        }
        [HttpPost]
        public IActionResult NewActivity(ActivityEntry activity)
        {
            reportsModel.AddActivity(activity, this.username);

            return RedirectToAction("UserMonth");
        }

        public IActionResult Details(string id)
        {
            var date = DateTime.Now;
            ViewBag.Reports = reportsModel.GetMonthReports(this.username, date, id);
            ViewBag.ProjectCode = id;
            TempData["Month"] = date;
            return View(new DateViewModel());

            // dynamic model = new ExpandoObject();
            // var date = DateTime.Now;

            // model.Date = date;
            // model.Reports = reportsModel.GetMonthReports(this.username, date, id);
            // model.ProjectCode = id;

            // return View(model);
        }
        [HttpPost]
        public IActionResult Details(DateViewModel model, string id)
        {
            var date = model.date;
            ViewBag.Reports = reportsModel.GetMonthReports(this.username, date, id);
            ViewBag.ProjectCode = id;
            TempData["Month"] = date;
            return View(model);
        }

        public IActionResult CloseMonth(string id)
        {
            Console.WriteLine($"Close month {id}");
            return RedirectToAction("Details", new {id = id});
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

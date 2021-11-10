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
    public class ActivitiesController : Controller
    {
        public ReportsViewModel reportsModel = new ReportsViewModel();
        public ProjectsViewModel projectsModel = new ProjectsViewModel();
        public string username {
            get {
                return HttpContext.Session.GetString("username");
            } 
            set {
                HttpContext.Session.SetString("username", value);
            }
        }

        private readonly ILogger<HomeController> _logger;

        public ActivitiesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Day() {
            var date = DateTime.Now;
            ViewBag.Reports = reportsModel.GetDayReports(date);
            return View();
        }

        [HttpPost]
        public IActionResult Day(DateViewModel model) {
            var date = model.date;
            ViewBag.Reports = reportsModel.GetDayReports(date);
            return View();
        }

        public IActionResult Month() {
            var date = DateTime.Now;
            ViewBag.Reports = reportsModel.GetMonthReports(date);
            return View();
        }

        [HttpPost]
        public IActionResult Month(DateViewModel model) {
            var date = model.date;
            ViewBag.Reports = reportsModel.GetMonthReports(date);
            return View();
        }

        public IActionResult UserDay() {
            if (this.username == null) 
                return RedirectToAction("Index", "Login");
            var date = DateTime.Now;
            ViewBag.Reports = reportsModel.GetDayReports(this.username, date);
            return View("Day");
        }

        [HttpPost]
        public IActionResult UserDay(DateViewModel model) {
            if (this.username == null) 
                return RedirectToAction("Index", "Login");
            var date = model.date;
            ViewBag.Reports = reportsModel.GetDayReports(this.username, date);
            return View("Day");
        }
        

        public IActionResult UserMonth() {
            if (this.username == null) 
                return RedirectToAction("Index", "Login");
            
            var date = DateTime.Now;
            ViewBag.Reports = reportsModel.GetMonthReports(this.username, date);
            return View("Month");
        }

        [HttpPost]
        public IActionResult UserMonth(DateViewModel model) {
            if (this.username == null) 
                return RedirectToAction("Index", "Login");
            
            var date = model.date;
            ViewBag.Reports = reportsModel.GetMonthReports(this.username, date);
            return View("Month");
        }

        public IActionResult Projects() {
            return View(projectsModel.GetProjects());
        }

        public IActionResult NewProject() {
            if (this.username == null) 
                return RedirectToAction("Index", "Login");
            ViewData["username"] = this.username;
            return View(new Project());
        }

        [HttpPost]
        public IActionResult NewProjectAddSubactivity(Project project) {
            if (this.username == null) 
                return RedirectToAction("Index", "Login");
            ViewData["username"] = this.username;
            return View("NewProject", project);
        }

        [HttpPost]
        public IActionResult NewProject(Project project) {
            var username = this.username;
            project.manager = username;
            projectsModel.AddProject(project);

            return RedirectToAction("Projects");
        }

        public IActionResult NewActivity(string id) {
            var newActivity = new ActivityEntry();
            newActivity.code = id;
            // dynamic expando = new ExpandoObject();
            // var model = expando as IDictionary<string, object>;

            ViewData["Code"] = id;
            ViewData["Subactivities"] = projectsModel.GetSubactivities(id);
            //model.subactivities
            return View(new ActivityEntry());
        }
        [HttpPost]
        public IActionResult NewActivity(ActivityEntry activity, string id) {
            reportsModel.AddActivity(activity);
            ViewData["Code"] = id;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

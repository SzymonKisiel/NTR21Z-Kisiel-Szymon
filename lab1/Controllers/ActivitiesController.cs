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
    public class ActivitiesController : Controller
    {
        public Reports reports = new Reports();
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
            var dateNow = DateTime.Now;
            reports.LoadDayActivities(dateNow.Year, dateNow.Month, dateNow.Day); 
            ViewBag.Reports = reports;
            return View();
        }

        [HttpPost]
        public IActionResult Day(DateViewModel model) {
            var date = model.date;
            reports.LoadDayActivities(date.Year, date.Month, date.Day); 
            ViewBag.Reports = reports;
            return View();
        }

        public IActionResult Month() {
            var dateNow = DateTime.Now;
            reports.LoadFromFiles(dateNow.Year, dateNow.Month); 
            ViewBag.Reports = reports;
            return View();
        }

        [HttpPost]
        public IActionResult Month(DateViewModel model) {
            var date = model.date;
            reports.LoadFromFiles(date.Year, date.Month);
            ViewBag.Reports = reports;
            return View();
        }

        public IActionResult UserDay() {
            if (this.username == null) 
                return RedirectToAction("Index", "Login");
            var dateNow = DateTime.Now;
            reports.LoadDayActivities(this.username, dateNow.Year, dateNow.Month, dateNow.Day); 
            ViewBag.Reports = reports;
            return View("Day");
        }

        [HttpPost]
        public IActionResult UserDay(DateViewModel model) {
            if (this.username == null) 
                return RedirectToAction("Index", "Login");
            var date = model.date;
            reports.LoadDayActivities(this.username, date.Year, date.Month, date.Day); 
            ViewBag.Reports = reports;
            return View("Day");
        }
        

        public IActionResult UserMonth() {
            if (this.username == null) 
                return RedirectToAction("Index", "Login");
            var dateNow = DateTime.Now;
            reports.LoadFromFiles(this.username, dateNow.Year, dateNow.Month);
            ViewBag.Reports = reports;
            return View("Month");
        }

        [HttpPost]
        public IActionResult UserMonth(DateViewModel model) {
            if (this.username == null) 
                return RedirectToAction("Index", "Login");
            var date = model.date;
            reports.LoadFromFiles(this.username, date.Year, date.Month);
            ViewBag.Reports = reports;
            return View("Month");
        }

        public IActionResult Projects() {
            var test = projectsModel.GetProjects();
            return View(projectsModel.GetProjects());
        }

        public IActionResult NewActivity() {
            return View();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

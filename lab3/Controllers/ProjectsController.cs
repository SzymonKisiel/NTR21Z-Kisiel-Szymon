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
        public TRSViewModel viewModel = new TRSViewModel();
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
            return View(viewModel.GetProjects());
        }

        public IActionResult NewProject()
        {
            if (this.username == null)
                return RedirectToAction("Index", "Login");
            ViewData["username"] = this.username;
            return View(new Project());
        }

        [HttpPost]
        public IActionResult NewProject(Project project, string button, string subactivity, string code)
        {
            if (this.username == null)
                return RedirectToAction("Index", "Login");
            
            switch (button)
            {
                case "+":
                    project.Subactivities.Add(new Subactivity { Name = subactivity });
                    return View(project);
                case "-":
                    project.Subactivities.Remove(project.Subactivities.First(a => a.Name == subactivity));
                    return View(project);
                case "Submit":
                    var username = this.username;
                    project.Manager = username;
                    viewModel.AddProject(project);

                    return RedirectToAction("Projects");
                default:
                    return RedirectToAction("Index", "Home");
            }            
        }

        public IActionResult NewActivity(string code, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var newActivity = new ActivityEntry();
            newActivity.Code = code;

            var firstDay = new DateTime(dateTime.Year, dateTime.Month, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);

            ViewData["Code"] = code;
            ViewData["Subactivities"] = viewModel.GetSubactivities(code);

            ViewData["FirstDay"] = firstDay.ToString("yyyy-MM-dd");
            ViewData["LastDay"] = lastDay.ToString("yyyy-MM-dd");

            return View(newActivity);
        }
        [HttpPost]
        public IActionResult NewActivity(ActivityEntry activity, string code)
        {
            var test = activity;
            viewModel.AddActivity(activity, this.username);

            return RedirectToAction("Projects");
        }

        public IActionResult Details(string code)
        {
            var date = DateTime.Now;
            ViewBag.Reports = viewModel.GetMonthReports(this.username, date, code);
            ViewBag.ProjectCode = code;
            ViewBag.Date = date.ToString("dd-MM-yyyy");
            ViewBag.IsEditable = viewModel.IsReportEditable(this.username, date, code);
            ViewBag.Accepted = viewModel.GetAcceptedTime(code, this.username, date);
            ViewBag.Frozen = viewModel.IsMonthClosed(this.username, date);
            
            return View(new DateViewModel());
        }
        [HttpPost]
        public IActionResult Details(DateViewModel model, string code)
        {
            var date = model.date;
            ViewBag.Reports = viewModel.GetMonthReports(this.username, date, code);
            ViewBag.ProjectCode = code;
            ViewBag.Date = date.ToString("dd-MM-yyyy");
            ViewBag.IsEditable = viewModel.IsReportEditable(this.username, date, code);
            ViewBag.Accepted = viewModel.GetAcceptedTime(code, this.username, date);
            ViewBag.Frozen = viewModel.IsMonthClosed(this.username, date);
            
            return View(model);
        }

        public IActionResult CloseMonth(string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);
            Console.WriteLine($"Close month {date}");
            viewModel.CloseMonth(this.username, dateTime);
            return RedirectToAction("UserMonth", "Activities");
        }

        public IActionResult DeleteActivity(int code) //code = activityID
        {
            viewModel.DeleteActivity(code);

            return RedirectToAction("Projects");
        }

        public IActionResult UpdateActivity(int code) //code = activityID
        {
            //DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);
            var activity = viewModel.GetActivity(code);

            DateTime dateTime = activity.Date;
            var firstDay = new DateTime(dateTime.Year, dateTime.Month, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);

            var projectCode = activity.Code;
            ViewData["Code"] = projectCode;
            ViewData["Subactivities"] = viewModel.GetSubactivities(projectCode);

            ViewData["FirstDay"] = firstDay.ToString("yyyy-MM-dd");
            ViewData["LastDay"] = lastDay.ToString("yyyy-MM-dd");
            ViewData["DefaultDay"] = dateTime.ToString("yyyy-MM-dd");

            EditViewModel model = new EditViewModel();
            model.activity = activity;
            model.id = code;

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateActivity(EditViewModel model)
        {
            viewModel.UpdateActivity(model.id, model.activity);
            return RedirectToAction("Projects");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

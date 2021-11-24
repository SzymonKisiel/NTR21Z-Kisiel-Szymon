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
    public class ManagerController : Controller
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

        public ManagerController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Projects()
        {
            if (this.username == null)
                return RedirectToAction("Index", "Login");
            var model = projectsModel.GetProjects();
            model.ToManagerProjects(this.username);
            return View(model);
        }

        public IActionResult ProjectClose(string code)
        {
            projectsModel.CloseProject(code);
            return RedirectToAction("Projects");
        }

        public IActionResult Details(string code)
        {
            var model = new ManagerDetailsViewModel();
            model.date = DateTime.Now;

            var date = model.date;

            var users = reportsModel.GetUsers(code, date);

            var username = users != null ? users[0] : "";

            model.accepted = reportsModel.GetAcceptedTime(code, username, date);

            ViewBag.Reports = reportsModel.GetMonthReports(username, date, code);
            ViewBag.Users = users;
            ViewBag.ProjectCode = code;
            ViewBag.Budget = projectsModel.GetBudget(code);
            ViewBag.AcceptedSum = reportsModel.GetAcceptedTimeSum(code, date);
            TempData["Month"] = date;
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Details(ManagerDetailsViewModel model, string code, string submitButton)
        {
            var date = model.date;
            var username = model.username;
            switch (submitButton) {
                case "Submit":
                    reportsModel.SetAcceptedTime(code, username, date, model.accepted);

                    ViewBag.Reports = reportsModel.GetMonthReports(username, date, code);
                    ViewBag.Users = reportsModel.GetUsers(code, date);
                    ViewBag.ProjectCode = code;
                    ViewBag.Budget = projectsModel.GetBudget(code);
                    ViewBag.AcceptedSum = reportsModel.GetAcceptedTimeSum(code);
                    TempData["Month"] = date;

                    return View(model);
                case "Show":
                    model.accepted = reportsModel.GetAcceptedTime(code, username, date);

                    ViewBag.Reports = reportsModel.GetMonthReports(username, date, code);
                    ViewBag.Users = reportsModel.GetUsers(code, date);
                    ViewBag.ProjectCode = code;
                    ViewBag.Budget = projectsModel.GetBudget(code);
                    ViewBag.AcceptedSum = reportsModel.GetAcceptedTimeSum(code);
                    TempData["Month"] = date;

                    ModelState.Clear();
                    return View(model);
                default:
                    return View(new ManagerDetailsViewModel());
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

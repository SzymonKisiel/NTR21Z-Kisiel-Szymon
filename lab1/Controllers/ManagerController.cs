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

        public IActionResult Details(string code)
        {
            var model = new ManagerDetailsViewModel();
            model.date = DateTime.Now;
            

            var date = model.date;
            var username = model.username;

            ViewBag.Reports = reportsModel.GetMonthReports(username, date, code);
            ViewBag.Users = reportsModel.GetUsers(code, date);
            ViewBag.ProjectCode = code;
            TempData["Month"] = date;
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Details(ManagerDetailsViewModel model, string code)
        {
            var date = model.date;
            var username = model.username;

            ViewBag.Reports = reportsModel.GetMonthReports(username, date, code);
            ViewBag.Users = reportsModel.GetUsers(code, date);
            ViewBag.ProjectCode = code;
            TempData["Month"] = date;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

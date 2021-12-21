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

        public ManagerController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Projects()
        {
            if (this.username == null)
                return RedirectToAction("Index", "Login");
            var projects = viewModel.GetProjects(this.username);
            return View(projects);
        }

        public IActionResult ProjectClose(string code)
        {
            viewModel.CloseProject(code);
            return RedirectToAction("Projects");
        }

        public IActionResult Details(string code)
        {
            var model = new ManagerDetailsViewModel();

            model.date = DateTime.Now;
            var date = model.date;

            var users = viewModel.GetUsers(code, date);
            var username = users != null && users.Count > 0 ? users[0] : "";

            model.accepted = viewModel.GetAcceptedTime(code, username, date);

            ViewBag.Reports = viewModel.GetMonthReports(username, date, code);
            ViewBag.Users = users;
            ViewBag.ProjectCode = code;
            ViewBag.Budget = viewModel.GetBudget(code);
            ViewBag.AcceptedSum = viewModel.GetAcceptedTimeSum(code, date);
            ViewBag.IsFrozen = viewModel.IsMonthClosed(username, date);
            ViewBag.IsActive = viewModel.IsActive(code);
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Details(ManagerDetailsViewModel model, string code, string submitButton)
        {
            var date = model.date;
            var username = model.username;
            switch (submitButton) {
                case "Submit":
                    viewModel.SetAcceptedTime(code, username, date, model.accepted);

                    ViewBag.Reports = viewModel.GetMonthReports(username, date, code);
                    ViewBag.Users = viewModel.GetUsers(code, date);
                    ViewBag.ProjectCode = code;
                    ViewBag.Budget = viewModel.GetBudget(code);
                    ViewBag.AcceptedSum = viewModel.GetAcceptedTimeSum(code);
                    ViewBag.IsFrozen = viewModel.IsMonthClosed(username, date);
                    ViewBag.IsActive = viewModel.IsActive(code);

                    return View(model);
                case "Show":
                    model.accepted = viewModel.GetAcceptedTime(code, username, date);

                    ViewBag.Reports = viewModel.GetMonthReports(username, date, code);
                    ViewBag.Users = viewModel.GetUsers(code, date);
                    ViewBag.ProjectCode = code;
                    ViewBag.Budget = viewModel.GetBudget(code);
                    ViewBag.AcceptedSum = viewModel.GetAcceptedTimeSum(code);
                    ViewBag.IsFrozen = viewModel.IsMonthClosed(username, date);
                    ViewBag.IsActive = viewModel.IsActive(code);

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

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
        private readonly ILogger<HomeController> _logger;
        public ReportsViewModel reportsModel = new ReportsViewModel();
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

        public ActivitiesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Day()
        {
            var date = DateTime.Now;
            ViewBag.Reports = reportsModel.GetDayReports(date);
            return View();
        }

        [HttpPost]
        public IActionResult Day(DateViewModel model)
        {
            var date = model.date;
            ViewBag.Reports = reportsModel.GetDayReports(date);
            return View();
        }

        public IActionResult Month()
        {
            var date = DateTime.Now;
            ViewBag.Reports = reportsModel.GetMonthReports(date);

            return View(new DateViewModel());
        }

        [HttpPost]
        public IActionResult Month(DateViewModel model)
        {

            var date = model.date;
            ViewBag.Reports = reportsModel.GetMonthReports(date);
            return View();
        }

        public IActionResult UserDay()
        {
            if (this.username == null)
                return RedirectToAction("Index", "Login");
            var date = DateTime.Now;
            ViewBag.Reports = reportsModel.GetDayReports(this.username, date);
            return View("Day");
        }

        [HttpPost]
        public IActionResult UserDay(DateViewModel model)
        {
            if (this.username == null)
                return RedirectToAction("Index", "Login");
            var date = model.date;
            ViewBag.Reports = reportsModel.GetDayReports(this.username, date);
            return View("Day");
        }

        public IActionResult UserMonth()
        {
            if (this.username == null)
                return RedirectToAction("Index", "Login");

            var date = DateTime.Now;
            ViewBag.Reports = reportsModel.GetMonthReports(this.username, date);
            return View("Month");
        }

        [HttpPost]
        public IActionResult UserMonth(DateViewModel model)
        {
            if (this.username == null)
                return RedirectToAction("Index", "Login");

            var date = model.date;
            ViewBag.Reports = reportsModel.GetMonthReports(this.username, date);
            return View("Month");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

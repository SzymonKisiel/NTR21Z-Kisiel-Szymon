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

        private readonly ILogger<HomeController> _logger;

        public ActivitiesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            reports.LoadFromFiles(2021, 10);
            return View(reports);
        }

        public IActionResult Day() {
            var dateNow = DateTime.Now;
            reports.LoadDayActivities(dateNow.Year, dateNow.Month, dateNow.Day); 
            ViewBag.Reports = reports;
            return View("Day");
        }

        [HttpPost]
        public IActionResult Day(DateViewModel model) {
            var date = model.date;
            reports.LoadDayActivities(date.Year, date.Month, date.Day); 
            ViewBag.Reports = reports;
            return View("Day");
        }

        public IActionResult Month() {
            var dateNow = DateTime.Now;
            reports.LoadFromFiles(dateNow.Year, dateNow.Month); 
            ViewBag.Reports = reports;
            return View("Month");
        }

        [HttpPost]
        public IActionResult Month(DateViewModel model) {
            var date = model.date;
            reports.LoadFromFiles(date.Year, date.Month);
            ViewBag.Reports = reports;
            return View("Month");
        }

        // TODO
        // public IActionResult DayActivity(DateTime date) {
        //     var reports = this.reports;
        //     //reports.getDayActivity(date);
        //     return View("Index", reports);
        // }

        // TODO
        // public IActionResult MonthActivity(DateTime date) {
        //     var reports = this.reports;
        //     //reports.getMonthActivity(date);
        //     return View(reports);
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

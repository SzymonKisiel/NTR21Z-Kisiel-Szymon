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
    public class HomeController : Controller
    {
        // private Reports _reports = new Reports();
        // public Reports reports { 
        //     get {
        //         _reports.LoadFromFiles();
        //         return _reports;
        //     } 
        //     set {
        //         value.SaveToFiles();
        //     }
        // }

        // Projects projects {
        //     get {
        //         string fileName = "activity.json";
        //         string jsonString = System.IO.File.ReadAllText(fileName);
        //         return JsonSerializer.Deserialize<Projects>(jsonString);
        //     }
        //     set {
        //         string fileName = "activity.json";
        //         string jsonString = JsonSerializer.Serialize<Projects>(value);
        //         System.IO.File.WriteAllText(fileName, jsonString);
        //     }
        // }

        public Reports reports = new Reports();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            reports.LoadFromFiles(2021, 10);
            return View(reports);
        }
        // [HttpPost]
        // public IActionResult Index(DateForm testy)
        // {
        //     Console.WriteLine($"Test = {testy.date}");
        //     return View();
        // }


        //[HttpPost]
        public IActionResult Test(DateViewModel testy) {
            //var reports = this.reports;
            Console.WriteLine($"Test = {testy.date}");
            //return View("Index", reports);
            return RedirectToAction("Index");
        }

        // TODO
        public IActionResult DayActivity(DateTime date) {
            var reports = this.reports;
            //reports.getDayActivity(date);
            return View("Index", reports);
        }

        // TODO
        public IActionResult MonthActivity(DateTime date) {
            var reports = this.reports;
            //reports.getMonthActivity(date);
            return View(reports);
        }

        public IActionResult Privacy()
        {
            return View(new DateViewModel());
        }
        [HttpPost]
        public IActionResult Privacy(DateViewModel testy)
        {
            Console.WriteLine($"Test = {testy.date}");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

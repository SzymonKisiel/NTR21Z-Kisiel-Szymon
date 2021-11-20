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
    public class LoginController : Controller
    {


        public string username {
            get {
                return HttpContext.Session.GetString("username");
            } 
            set {
                HttpContext.Session.SetString("username", value);
            }
        }

        private readonly ILogger<HomeController> _logger;

        public LoginController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            this.username = model.username;
            TempData["Username"] = this.username;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Test() {
            return View();
        }
        // public IActionResult Login(LoginViewModel model, string returnUrl)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         return Hop(returnUrl);
        //     }
        // }

        // public IActionResult Hop(string returnUrl)
        // {
        //     Session["UserName"] = User.Identity.Name;
        //     return Redirect(returnUrl);
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace TRS.Models
{
    public class LoginViewModel
    {
        public string username { 
            get {
                return HttpContext.Session.GetString("username");
            } 
            set {
                HttpContext.Session.SetString("username", value);
            }
    }
}

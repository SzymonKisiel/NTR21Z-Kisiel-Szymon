using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace TRS.Models
{
    public class EditViewModel
    {
        public string oldCode { get; set; } = "";
        //public string username { get; set; } = "";
        public DateTime oldDate { get; set; } = DateTime.Now;
        public ActivityEntry activity { get; set; }
    }   
}

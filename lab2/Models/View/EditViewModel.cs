using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace TRS.Models
{
    public class EditViewModel
    {
        public int id { get; set; }
        public ActivityEntry activity { get; set; }
    }   
}

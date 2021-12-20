using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRS.Models
{
    public class ManagerDetailsViewModel
    {
        public DateTime date { get; set; } = DateTime.Now;
        public string username { get; set; } = "";
        public int accepted { get; set; } = 0;
    }
}

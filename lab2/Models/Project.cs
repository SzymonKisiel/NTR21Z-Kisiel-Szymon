using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRS.Models
{
    public class Project
    {
        public string code { get; set; }
        public string manager { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string name { get; set; }
        public int budget { get; set; }
        public bool active { get; set; } = true;
        public List<string> subactivities { get; set; } = new List<string>();

        public void AddSubactivity(string subactivity)
        {
            subactivities.Add(subactivity);
        }

        public void DeleteSubactivity(string subactivity)
        {
            subactivities.Remove(subactivity);
        }
    }
}
using System;
using System.Collections.Generic;

namespace TRS.Models
{
    public class Project
    {
        public string code { get; set; }
        public string manager { get; set; }
        public string name { get; set; }
        public int budget { get; set; }
        public bool active { get; set; }
        public List<string> subactivities { get; set; }
    }
}
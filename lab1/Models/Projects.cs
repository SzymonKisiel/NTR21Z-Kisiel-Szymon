using System;
using System.Collections.Generic;

using System.Text.Json;
using System.IO;

namespace TRS.Models
{
    public class Projects
    {
        public const string filename = "Data/activity.json";
        public List<Project> activities { get; set; }

        public void LoadAllFromFiles()
        {
            string jsonString = System.IO.File.ReadAllText(filename);
            activities = JsonSerializer.Deserialize<List<Project>>(jsonString);
        }
    }
}
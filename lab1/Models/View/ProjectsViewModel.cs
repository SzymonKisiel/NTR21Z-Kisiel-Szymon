using System;
using System.Collections.Generic;

using System.Text.Json;
using System.IO;

namespace TRS.Models
{
    public class ProjectsViewModel
    {
        public const string filename = "Data/activity.json";
        public Projects projects { get; set; }

        private void LoadAllFromFile()
        {
            string jsonString = System.IO.File.ReadAllText(filename);
            Console.WriteLine(jsonString);
            projects = JsonSerializer.Deserialize<Projects>(jsonString);
        }

        private void SaveToFile()
        {
            string jsonString = JsonSerializer.Serialize<Projects>(projects);
            System.IO.File.WriteAllText(filename, jsonString);
        }

        public Projects GetProjects()
        {
            LoadAllFromFile();
            return projects;
        }

        public void AddProject(Project project)
        {
            LoadAllFromFile();
            projects.AddProject(project);
            SaveToFile();
        }

        public void DeleteProject(string projectCode)
        {
            projects.DeleteProject(projectCode);
        }
    }
}
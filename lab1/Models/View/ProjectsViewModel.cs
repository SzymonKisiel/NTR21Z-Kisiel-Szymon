using System;
using System.Collections.Generic;

using System.Text.Json;
using System.IO;

namespace TRS.Models
{
    public class ProjectsViewModel
    {
        public const string filename = "Data/activity.json";
        //public Projects projects { get; set; }

        private Projects LoadFromFile()
        {
            string jsonString = System.IO.File.ReadAllText(filename);
            //Console.WriteLine(jsonString);
            Projects projects = JsonSerializer.Deserialize<Projects>(jsonString);
            return projects;
        }

        private void SaveToFile(Projects projects)
        {
            string jsonString = JsonSerializer.Serialize<Projects>(projects);
            System.IO.File.WriteAllText(filename, jsonString);
        }

        public Projects GetProjects()
        {
            return LoadFromFile();
        }

        public Projects GetProjects(string manager) {
            var projects = LoadFromFile(); 
            // todo
            return projects;
        }

        public List<string> GetSubactivities(string code)
        {
            foreach (var project in GetProjects().projects)
            {
                if (project.code == code)
                {
                    return project.subactivities;
                }
            }
            return new List<string>();
        }

        public void AddProject(Project project)
        {
            var projects = LoadFromFile();
            projects.AddProject(project);
            SaveToFile(projects);
        }

        // public void DeleteProject(string projectCode)
        // {
            //var projects = LoadFromFile();
            //projects.DeleteProject(projectCode);
            //SaveToFile(projects);
        // }

        public void CloseProject(string projectCode)
        {
            var projects = LoadFromFile();
            projects.CloseProject(projectCode);
            SaveToFile(projects);
        }
    }
}
using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace TRS.Models
{
    public class Projects
    {
        [JsonPropertyName("activities")]
        public List<Project> projects { get; set; }
        public void AddProject(Project project)
        {
            projects.Add(project);
        }
        public void DeleteProject(string projectCode)
        {
            var index = projects.FindIndex(project => project.code == projectCode);
            projects.RemoveAt(index);
        }
        public void ToManagerProjects(string manager)
        {
            List<Project> result = new List<Project>();
            foreach (Project project in projects)
            {
                if (project.manager == manager)
                {
                    result.Add(project);
                }
            }
            this.projects = result;
        }
    }
}
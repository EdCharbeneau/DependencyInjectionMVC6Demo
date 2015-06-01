using DependencyInjectionMVC6Demo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DependencyInjectionMVC6Demo.Services
{
    public class GitHubService : IProjectService
    {

        private readonly string organizationEndpoint = "https://api.github.com/orgs/{0}";
        private readonly string projectsEndpoint = "https://api.github.com/orgs/{0}/repos";

        public string Name { get; }

        public GitHubService(string name)
        {
            Name = name;
        }
        public Organization GetOrganization()
        {
            var taskOrganization = FetchOrganization();
            var taskProjects = FetchProjects();

            Task.WaitAll(taskOrganization, taskProjects);

            var organization = taskOrganization.Result;
            organization.Projects = taskProjects.Result.AsQueryable();

            return organization;
        }

        private IQueryable<Project> GetProjects()
        {
            return FetchProjects().Result.AsQueryable();
        }

        private async Task<string> FetchJsonAsync(string endpoint)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("user-agent", "none");
                HttpResponseMessage response = await client.GetAsync(string.Format(endpoint, Name));
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            return responseBody;
        }

        private async Task<Organization> FetchOrganization()
        {
            var json = await FetchJsonAsync(organizationEndpoint);
            var organization = JsonConvert.DeserializeObject<Organization>(json);
            return organization;
        }

        private async Task<List<Project>> FetchProjects()
        {
            var json = await FetchJsonAsync(projectsEndpoint);
            var projects = JsonConvert.DeserializeObject<List<Project>>(json);
            return projects;
        }
    }
}

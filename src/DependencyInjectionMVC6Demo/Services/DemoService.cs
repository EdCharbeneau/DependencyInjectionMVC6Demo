using DependencyInjectionMVC6Demo.Models;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjectionMVC6Demo.Services
{
    public class DemoService : IProjectService
    {
        public string Name { get; } = "Demo";

        public Organization GetOrganization() => new Organization
        {
            Name = this.Name,
            AvatarUrl = $"http://placehold.it/100&text={this.Name}",
            Projects = GetProjects()
        };

        private IQueryable<Project> GetProjects() => new List<Project> {
             new Project {
                 Id = 0,
                 Description = "Test project 0",
                 Name = "Test 0",
                 Stars = 120
             },
             new Project { Id = 1, Description = "Test project 1", Name = "Test 1", Stars = 0},
             new Project { Id = 2, Description = "Test project 2", Name = "Test 2", Stars = 5},
             new Project { Id = 3, Description = "Test project 3", Name = "Test 3", Stars = 15},
             new Project {
                 Id = 4,
                 Description = "Test project 4",
                 Name = "Test 4",
                 Stars = 89
             }
        }.AsQueryable();
    }
}
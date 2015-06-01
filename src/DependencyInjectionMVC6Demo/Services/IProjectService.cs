using DependencyInjectionMVC6Demo.Models;

namespace DependencyInjectionMVC6Demo.Services
{
    public interface IProjectService
    {
        string Name { get; }
        Organization GetOrganization();
    }
}

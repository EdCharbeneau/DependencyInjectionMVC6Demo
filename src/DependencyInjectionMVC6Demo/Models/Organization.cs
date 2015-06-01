using Newtonsoft.Json;
using System.Linq;

namespace DependencyInjectionMVC6Demo.Models
{
    public class Organization
    {
        public string Name { get; set; }
        [JsonProperty("Avatar_Url")]

        public string AvatarUrl { get; set; }
        public IQueryable<Project> Projects { get; set; }
    }
}

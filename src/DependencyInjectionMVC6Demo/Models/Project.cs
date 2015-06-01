using Newtonsoft.Json;

namespace DependencyInjectionMVC6Demo.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonProperty("stargazers_count")]
        public int Stars { get; set; }
        public string Url { get; set; }
    }
}

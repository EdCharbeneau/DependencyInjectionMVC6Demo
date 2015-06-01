using DependencyInjectionMVC6Demo.Models;
using DependencyInjectionMVC6Demo.Services;
using Microsoft.AspNet.Mvc;

namespace DependencyInjectionMVC6Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectService projectService;
        public HomeController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        public IActionResult Index()
        {
            Organization org = projectService.GetOrganization();
            return View(org);
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}

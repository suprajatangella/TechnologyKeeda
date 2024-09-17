using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnologyKeeda.Web.Models;

namespace TechnologyKeeda.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<People> people = new List<People>();
            people.Add(new People { Id = 1, Name = "Tarun", City = "Jaipur" });
            people.Add(new People { Id = 2, Name = "Ram", City = "Delhi" });
            people.Add(new People { Id = 3, Name = "Shyam", City = "Kota" });
            people.Add(new People { Id = 4, Name = "Mohan", City = "Ajmer" });
            return View(people);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

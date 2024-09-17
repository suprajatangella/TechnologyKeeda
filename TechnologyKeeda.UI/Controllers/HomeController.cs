using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnologyKeeda.Repositories.Interfaces;
using TechnologyKeeda.UI.Models;

namespace TechnologyKeeda.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountryRepo _countryRepo;

        public HomeController(ILogger<HomeController> logger, ICountryRepo countryRepo)
        {
            _logger = logger;
            _countryRepo = countryRepo;
        }

        public IActionResult Index()
        {
            return View();
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

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using TechnologyKeeda.Entities;
using TechnologyKeeda.Repositories.Interfaces;
using TechnologyKeeda.UI.ViewModels.CountryViewModels;

namespace TechnologyKeeda.UI.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryRepo _countryRepo;
        

        public CountriesController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                List<CountryViewModel> vmList = new List<CountryViewModel>();
                var countries = await _countryRepo.GetAll();
                foreach (var country in countries)
                {
                    vmList.Add(new CountryViewModel
                    {
                        Id = country.Id,
                        Name = country.Name,
                    });
                }
                return View(vmList);
            }
            return RedirectToAction("Index", "Auth");
        }

        public IActionResult Create()
        {
            var countryVM = new CreateCountryViewModel();
            return View(countryVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var country = new Country { Name = vm.Name };
                await _countryRepo.Save(country);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var country = await _countryRepo.GetById(id);
            CountryViewModel vm = new CountryViewModel
            {
                Id=country.Id,
                Name = country.Name
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CountryViewModel vm)
        {
            Country country = new Country 
            { 
                Id = vm.Id,
                Name = vm.Name
            };
            await _countryRepo.Edit(country);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var country = await _countryRepo.GetById(id);
            CountryViewModel vm = new CountryViewModel
            {
                Id = country.Id,
                Name = country.Name
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CountryViewModel vm)
        {
            var country = new Country
            {
                Id = vm.Id,
                Name = vm.Name
            };
             await _countryRepo.Delete(country);
            return RedirectToAction(nameof(Index));
        }
    }
}

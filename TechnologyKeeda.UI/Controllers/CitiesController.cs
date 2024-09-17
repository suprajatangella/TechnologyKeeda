using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnologyKeeda.Entities;
using TechnologyKeeda.Repositories.Implementations;
using TechnologyKeeda.Repositories.Interfaces;
using TechnologyKeeda.UI.ViewModels.CityViewModels;

namespace TechnologyKeeda.UI.Controllers
{
    public class CitiesController : Controller
    {
        private readonly IStateRepo _stateRepo;
        private readonly ICityRepo _cityRepo;

        public CitiesController(IStateRepo stateRepo, ICityRepo cityRepo)
        {
            _stateRepo = stateRepo;
            _cityRepo = cityRepo;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _cityRepo.GetAll();
            List<CityViewModel> list = new List<CityViewModel>();
            foreach(var c in cities)
            {
                list.Add(new CityViewModel
                {
                    Id = c.Id,
                    CityName = c.Name,
                    StateName = c.State.Name,
                    CountryName = c.State.Country.Name
                });
            }
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            var cityVM = new CreateCityViewModel();
            var states = await _stateRepo.GetAll();
            ViewBag.StateList = new SelectList(states, "Id", "Name");
            return View(cityVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCityViewModel cityVM)
        {
            var city = new City
            {
                Name = cityVM.CityName,
                StateId = cityVM.StateId
            };
            await _cityRepo.Save(city);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var city = await _cityRepo.GetById(id);

            var cityVM = new EditCityViewModel { 
                Id = city.Id,
                CityName = city.Name,
            };
            var states = await _stateRepo.GetAll();
            ViewBag.StateList = new SelectList(states, "Id", "Name");

            return View(cityVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditCityViewModel cityVM)
        {
            var city = new City
            {
                Id = cityVM.Id,
                Name = cityVM.CityName,
                StateId= cityVM.StateId
            };

            await _cityRepo.Edit(city);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var city = await _cityRepo.GetById(id);
            var cityVM = new DeleteCityViewModel
            {
                Id = city.Id,
                CityName = city.Name,
                StateName = city.State.Name
            };
            return View(cityVM);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCityViewModel cityVM)
        {
            var city = new City
            {
                Id = cityVM.Id,
                Name = cityVM.CityName,
            };
            await _cityRepo.Delete(city);
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnologyKeeda.Entities;
using TechnologyKeeda.Repositories.Implementations;
using TechnologyKeeda.Repositories.Interfaces;
using TechnologyKeeda.UI.ViewModels.StateViewModels;

namespace TechnologyKeeda.UI.Controllers
{
    public class StatesController : Controller
    {
        private readonly IStateRepo _stateRepo;
        private readonly ICountryRepo _countryRepo;

        public StatesController(IStateRepo stateRepo, ICountryRepo countryRepo)
        {
            _stateRepo = stateRepo;
            _countryRepo = countryRepo;
        }

        public async Task<IActionResult> Index()
        {
            var states = await _stateRepo.GetAll();
            List<StateViewModel> list = new List<StateViewModel>();

            foreach(var state in states)
            {
                list.Add(new StateViewModel 
                { 
                    Id= state.Id,
                    StateName= state.Name,
                    CountryName = state.Country.Name
                }

                );
            }

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var countries = await _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            CreateStateViewModel vm = new CreateStateViewModel();
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStateViewModel vm)
        {
            var state = new State
            {
                Name = vm.StateName,
                CountryId = vm.CountryId
            };
            await _stateRepo.Save(state);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var state = await _stateRepo.GetById(id);
            var countries = await _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            EditStateViewModel vm = new EditStateViewModel
            {
                Id = id,
                StateName = state.Name,
                CountryId= state.CountryId
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditStateViewModel vm)
        {
            var state = new State
            {
                CountryId = vm.CountryId,
                Name = vm.StateName,
                Id = vm.Id

            };
            await _stateRepo.Edit(state);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var state = await _stateRepo.GetById(id);
            DeleteStateViewModel vm = new DeleteStateViewModel
            { 
                  Id = state.Id,
                  StateName= state.Name,
                  CountryName = state.Country.Name
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteStateViewModel vm)
        {
             var state = new State
                { 
                  Id = vm.Id,
                  Name = vm.StateName
             };
            await _stateRepo.Delete(state);
            return RedirectToAction(nameof(Index));
        }
    }
}

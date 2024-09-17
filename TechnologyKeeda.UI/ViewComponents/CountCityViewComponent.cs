using Microsoft.AspNetCore.Mvc;
using TechnologyKeeda.Repositories.Interfaces;

namespace TechnologyKeeda.UI.ViewComponents
{
    public class CountCityViewComponent : ViewComponent
    {
        private ICityRepo _cityRepo;
        public CountCityViewComponent(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
                
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cities = await _cityRepo.GetAll();
            int totalCities = cities.Count();
            return View(totalCities);
        }
    }
}

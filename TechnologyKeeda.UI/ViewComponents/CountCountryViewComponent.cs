using Microsoft.AspNetCore.Mvc;
using TechnologyKeeda.Repositories.Interfaces;

namespace TechnologyKeeda.UI.ViewComponents
{
    public class CountCountryViewComponent : ViewComponent
    {
        private ICountryRepo _countryRepo;
        public CountCountryViewComponent(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var countries = await _countryRepo.GetAll();
            int totalCountries = countries.Count();
            return View(totalCountries);
        }
    }
}

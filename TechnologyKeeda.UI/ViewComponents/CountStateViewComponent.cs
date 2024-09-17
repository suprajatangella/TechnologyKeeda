using Microsoft.AspNetCore.Mvc;
using TechnologyKeeda.Repositories.Interfaces;

namespace TechnologyKeeda.UI.ViewComponents
{
    public class CountStateViewComponent : ViewComponent
    {
        private IStateRepo _stateRepo;
        public CountStateViewComponent(IStateRepo stateRepo)
        {
            _stateRepo = stateRepo;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var states = await _stateRepo.GetAll();
            int totalStates = states.Count();
            return View(totalStates);
        }
    }
}

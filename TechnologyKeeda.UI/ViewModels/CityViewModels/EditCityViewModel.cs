using System.ComponentModel.DataAnnotations;

namespace TechnologyKeeda.UI.ViewModels.CityViewModels
{
    public class EditCityViewModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        [Display(Name = "State Names")]
        public int StateId { get; set; }
    }
}

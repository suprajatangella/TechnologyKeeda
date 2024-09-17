using System.ComponentModel.DataAnnotations;

namespace TechnologyKeeda.UI.ViewModels.StateViewModels
{
    public class CreateStateViewModel
    {
        public string StateName { get; set; }
        [Display(Name = "Country Name")]
        public int CountryId { get; set; }
    }
}

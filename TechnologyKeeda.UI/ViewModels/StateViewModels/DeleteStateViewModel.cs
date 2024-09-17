using System.ComponentModel.DataAnnotations;

namespace TechnologyKeeda.UI.ViewModels.StateViewModels
{
    public class DeleteStateViewModel
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyKeeda.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Andhra Pradesh";

        public int CountryId { get; set; }

        public Country? Country { get; set; }
        public ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}

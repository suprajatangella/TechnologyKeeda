using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyKeeda.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Hyderabad";

        public int StateId { get; set; }
        public State? State { get; set; } 
    }
}

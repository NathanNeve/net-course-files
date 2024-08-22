using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventures.Domain.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        
        public ICollection<Trip>? Trips { get; set; }
    }
}

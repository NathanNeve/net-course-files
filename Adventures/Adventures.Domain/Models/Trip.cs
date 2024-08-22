using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventures.Domain.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public string Title { get; set; }
        public int CountryId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Days { get; set; }

        public Country? Country { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}

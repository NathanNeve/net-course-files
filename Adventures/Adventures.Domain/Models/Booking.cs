using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventures.Domain.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int TravellerId { get; set; }
        public int TripId { get; set; }


        public Traveller? Traveller { get; set; }
        public Trip? Trip { get; set; }
    }
}

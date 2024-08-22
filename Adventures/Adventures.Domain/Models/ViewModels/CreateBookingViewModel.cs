using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.Rendering;

namespace Adventures.Domain.Models.ViewModels
{
    public class CreateBookingViewModel
    {
        public int TripID { get; set; }
        public string TripName { get; set; }
        //public SelectList Travellers { get; set; }
        public int TravellerID { get; set; }

    }
}

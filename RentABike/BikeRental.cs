using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentABike
{
    internal class BikeRental
    {
        public List<Bike> OverviewRentals = new();
        
        public void RegisterRent(Bike bike)
        {
            if (OverviewRentals.Contains(bike)) { 
            } else
            {
                OverviewRentals.Add(bike);
            }
        }

        public void DeRegisterRent(Bike bike)
        {
            if (OverviewRentals.Contains(bike)) {
                OverviewRentals.Remove(bike);
            }
        }
    }
}

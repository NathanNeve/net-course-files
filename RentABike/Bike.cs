using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentABike
{
    internal class Bike : Material
    {
        private static Random random = new Random();
        private const int MinCode = 100;
        private const int MaxCode = 999;

        public string _code { get; private set; }

        public Bike(string serialNumber, string description) : base(serialNumber, description)
        {
            _code = random.Next(MinCode, MaxCode + 1).ToString();
        }

        public override double ReturnRentalPrice()
        {
            double basePrice = base.ReturnRentalPrice();
            double newPrice = basePrice * 1.2;

            return newPrice;
        }

        public override string ToString()
        {
            return $"{_serialNumber} {_description} {_code} rental price is = '{ReturnRentalPrice()}'";
        }
    }
}
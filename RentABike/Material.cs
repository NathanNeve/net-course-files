using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentABike
{
    internal class Material
    {
        public string _serialNumber { get; set; }
        public string _description { get; set; }

        public Material(string serialNumber, string description)
        {
            _serialNumber = serialNumber;
            _description = description;
        }

        public virtual double ReturnRentalPrice()
        {
            return 100;
        }
    }
}

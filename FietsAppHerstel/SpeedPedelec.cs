using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FietsAppHerstel
{
    internal class SpeedPedelec : Fiets
    {
        public int Capacity = 100;


        public SpeedPedelec(string material, string color, int framesize, int capacity) : base(material, color, framesize) {
            Capacity = capacity;
        }

        public void Charge()
        {
            Console.WriteLine("Charging babyyy");
        }

        public override string ToString()
        {
            return "Noot NOOT";
        }
    }
}

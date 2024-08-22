using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FietsAppHerstel
{
    internal class Fiets : IFiets
    {
        private int _frameSize = 0;

        // constructor
        // ctor
        public Fiets(string material, string color, int frameSize)
        {
            Material = material;
            Color = color;
            FrameSize = frameSize;
        }

        // properties = attributen
        // encapsulation zorgt ervoor dat er grenzen zijn aan wat de property kan zijn
        public string Material { get; set; }
        public string Color { get; set; }
        public int FrameSize { 
        get
            {
                return _frameSize;
            }
        set
            {
                //44-64
                if (value <= 44 || value >= 64) 
                { 
                    throw new Exception($"invalid value frame size ({value})");
                } else
                {
                    _frameSize = value;
                }
                _frameSize = value;
            }
        }

        // methoden
        public void Stop() 
        {
            Console.WriteLine("Stop!");
        }

        public void Ride() 
        {
            Console.WriteLine("Ride!");
            // Carbon, Yellow, 53
            // Aluminium, pink, 48
        }

        public override string ToString()
        {
            return $"{Material}, {Color} ({FrameSize})";
        }

        public void Steer()
        {
            throw new NotImplementedException();
        }

        public virtual string Ring()
        {
            return "Ring Ring";
        }
    }
}

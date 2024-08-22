using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FietsAppHerstel
{
    internal interface IFiets
    {
        public string Material { get; set; }
        public string Color { get; set; }
        public int FrameSize { get; set; }
        public void Stop();
        public void Ride();
        public void Steer();
        public string ToString();
    }
}

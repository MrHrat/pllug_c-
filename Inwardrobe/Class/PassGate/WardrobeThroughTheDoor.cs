using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class WardrobeThroughTheDoor : PassGate
    {
        public WardrobeThroughTheDoor(Door door, Wardrobe wardrobe) : base(door, wardrobe) { }        
    }
}

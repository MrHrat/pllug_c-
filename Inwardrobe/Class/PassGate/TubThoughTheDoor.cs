using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{    
    public class TubThoughTheDoor : PassGate
    {
        public TubThoughTheDoor(Door door, Tub tub) : base(door, tub) { }

        public override string MoveTheGate()
        {
            string rezult = "";
            if (Inequality(Gate, VBody.Width, VBody.Height))
            {
                rezult += "Push it;";
            }
            else if (Inequality(Gate, VBody.Height, VBody.Width))
            {
                rezult += "Lay on the side surface and push;";
            }
            return rezult;
        }
    }
}

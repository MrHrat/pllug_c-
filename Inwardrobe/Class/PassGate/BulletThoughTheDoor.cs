using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class BulletThoughTheDoor : PassGate
    {
        public BulletThoughTheDoor(Door door, Bullet bullet) : base(door, bullet) { }

        public override string MoveTheGate()
        {
            string rezult = "";
            if (Inequality(Gate, VBody.Width, VBody.Height))
            {
                rezult += "Roll the ball;";
            }
            return rezult;
        }
    }
}

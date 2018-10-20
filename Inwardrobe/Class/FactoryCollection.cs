using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class FactoryCollection
    {
        public static PassGate GetPassGate(Door door, Wardrobe wardrobe)
        {
            return new WardrobeThroughTheDoor(door, wardrobe);
        }

        public static PassGate GetPassGate(Door door, Bullet bullet)
        {
            return new BulletThoughTheDoor(door, bullet);
        }

        public static PassGate GetPassGate(Door door, Tub tub)
        {
            return new TubThoughTheDoor(door, tub);
        }
    }
}

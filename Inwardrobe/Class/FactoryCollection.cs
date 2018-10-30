using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class FactoryCollection
    {
        public static PassGate GetPassGate(Passageway passageway, VolumetricBody body)
        {
            switch (body.GetType().ToString())
            {
                case "Wardrobe":
                    return new WardrobeThroughTheDoor(passageway as Door, body as Wardrobe);
                case "Bullet":
                    return new BulletThoughTheDoor(passageway as Door, body as Bullet);
                case "Tub":
                    return new TubThoughTheDoor(passageway as Door, body as Tub);
                default:
                    return new PassGate(passageway, body);
            }
        }
    }
}

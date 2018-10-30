using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Inwardrobe.Class
{
    public class FactoryCollection
    {
        public static PassGate GetPassGate(Passageway passageway, VolumetricBody body)
        {
            switch (passageway.GetType().Name + body.GetType().Name)
            {
                case "DoorWardrobe":
                    return new WardrobeThroughTheDoor(passageway as Door, body as Wardrobe);
                case "ArchBullet":                    
                    return new BulletThoughTheArch(passageway as Arch, body as Bullet);
                case "DoorBullet":
                    return new BulletThoughTheDoor(passageway as Door, body as Bullet);
                case "DoorTub":
                    return new TubThoughTheDoor(passageway as Door, body as Tub);
                default:
                    return new PassGate(passageway, body);
            }
        }
    }
}

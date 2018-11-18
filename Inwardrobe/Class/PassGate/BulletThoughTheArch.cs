using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class BulletThoughTheArch : PassGate
    {
        public BulletThoughTheArch(Arch arch, Bullet bullet) : base(arch, bullet) { }

        public override string MoveTheGate()
        {
            string rezult = "";
            var arch = Gate as Arch;
            var bullet = VBody as Bullet;
            if ((arch.Radius >= bullet.Radius) && (arch.Height >= bullet.Height))
            {
                rezult += "Roll the ball;";
            }
            return rezult;
        }
    }
}

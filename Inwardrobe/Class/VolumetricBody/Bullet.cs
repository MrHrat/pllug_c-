using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class Bullet : VolumetricBody
    {
        private double _diameter
        {
            get => Radius * 2.0;
            set => Radius = value / 2.0;
        }

        public double Radius { get; set; }

        public override double Width => _diameter;

        public override double Height => _diameter;

        public override double Depth => _diameter;


        public Bullet(double radius)
        {
            Radius = radius;
        }
    }
}

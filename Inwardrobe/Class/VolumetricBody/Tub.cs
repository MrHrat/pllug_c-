using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class Tub : VolumetricBody
    {
        private double _radius;
        
        public override double Width
        {
            get => Diameter;
            set => Diameter = value;
        }

        public override double Depth
        {
            get => Diameter;
            set => Diameter = value;
        }

        public double Diameter
        {
            get => _radius * 2.0;
            set => _radius = value / 2.0;
        }

        public Tub(double radius, double height)
        {
            _radius = radius;
            Height = height;
        }
    }
}

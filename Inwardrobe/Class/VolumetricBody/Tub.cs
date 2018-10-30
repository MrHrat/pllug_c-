using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class Tub : VolumetricBody, IReadParam
    {
        private double _radius;

        public override double Width => Diameter;

        public override double Depth => Diameter;

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

        public override void SetParamValue(Dictionary<string, double> keyValuePairs)
        {
            Height = keyValuePairs["Height"];
            Diameter = keyValuePairs["Diameter"];
        }
    }
}

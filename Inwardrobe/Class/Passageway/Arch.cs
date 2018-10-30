using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class Arch : Passageway, IReadParam
    {
        private double _diameter
        {
            get => Radius * 2.0;
            set => Radius = value / 2.0;
        }

        public double Radius { get; set; }

        public override double Width => _diameter;
        
        public Arch(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }

        public override void SetParamValue(Dictionary<string, double> keyValuePairs)
        {
            Height = keyValuePairs["Height"];
            Radius = keyValuePairs["Radius"];
        }
    }
}

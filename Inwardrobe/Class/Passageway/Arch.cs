using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inwardrobe.Class
{
    [Serializable]
    public class Arch : Passageway
    {
        [XmlIgnore]
        private double _diameter
        {
            get => Radius * 2.0;
            set => Radius = value / 2.0;
        }

        public double Radius { get; set; }

        [XmlIgnore]
        public override double Width => _diameter;

        public Arch()
        {
            Radius = 0.0;
            Height = 0.0;
        }

        public Arch(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }
    }
}

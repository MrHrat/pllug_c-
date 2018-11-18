﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    [Serializable]
    public class Tub : VolumetricBody
    {
        private double _radius;

        public override double Width => Diameter;

        public override double Depth => Diameter;

        public double Diameter
        {
            get => _radius * 2.0;
            set => _radius = value / 2.0;
        }

        public Tub()
        {
            _radius = 0.0;
            Height = 0.0;
        }

        public Tub(double radius, double height)
        {
            _radius = radius;
            Height = height;
        }
    }
}

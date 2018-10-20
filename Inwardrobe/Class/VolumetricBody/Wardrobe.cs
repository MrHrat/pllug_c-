using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class Wardrobe : VolumetricBody
    {
        public Wardrobe(double width, double height, double depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }        
    }
}

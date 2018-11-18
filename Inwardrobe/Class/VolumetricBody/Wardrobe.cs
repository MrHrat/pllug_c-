using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    [Serializable]
    public class Wardrobe : VolumetricBody
    {
        public Wardrobe()
        {
            Width = 0.0;
            Height = 0.0;
            Depth = 0.0;
        }

        public Wardrobe(double width = 0.0, double height = 0.0, double depth = 0.0)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }        
    }
}

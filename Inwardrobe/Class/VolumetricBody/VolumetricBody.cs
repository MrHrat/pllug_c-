using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    [Serializable]
    public abstract class VolumetricBody
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }
        public virtual double Depth { get; set; }
    }
}

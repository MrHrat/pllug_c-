using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    [Serializable]
    public abstract class Passageway
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }
    }
}

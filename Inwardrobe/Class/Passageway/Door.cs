using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    [Serializable]
    public class Door : Passageway
    {
        public Door()
        {
            Width = 0.0;
            Height = 0.0;
        }

        public Door(double widht, double height)
        {
            Width = widht;
            Height = height;
        }
    }
}

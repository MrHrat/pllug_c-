using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class Door : Passageway
    {
        public Door(double widht, double height)
        {
            Width = widht;
            Height = height;
        }
    }
}

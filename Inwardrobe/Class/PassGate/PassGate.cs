using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class PassGate
    {
        public Passageway Gate { get; set; }
        public VolumetricBody VBody { get; set; }

        public PassGate(Passageway passageway, VolumetricBody volumetricBody)
        {
            Gate = passageway;
            VBody = volumetricBody;
        }

        public virtual string MoveTheGate()
        {
            string rezult = "";
            if (Inequality(Gate, VBody.Width, VBody.Height))
            {
                rezult += "Push it;";
            }
            else if (Inequality(Gate, VBody.Height, VBody.Width))
            {
                rezult += "Turn the front view and push;";
            }
            else if (Inequality(Gate, VBody.Width, VBody.Depth))
            {
                rezult += "Lower front view and push;";
            }
            else if (Inequality(Gate, VBody.Depth, VBody.Width))
            {
                rezult += "Fold the front view, rotate and push;";
            }
            else if (Inequality(Gate, VBody.Height, VBody.Depth))
            {
                rezult += "Rotate the bottom view, turn the front view and push;";
            }
            else if (Inequality(Gate, VBody.Depth, VBody.Height))
            {
                rezult += "Rotate the bottom view and push;";
            }
            return rezult;
        }

        public static bool Inequality(Passageway passageway, double width, double height)
        {
            return passageway.Width >= width && passageway.Height >= height;            
        }
    }
}

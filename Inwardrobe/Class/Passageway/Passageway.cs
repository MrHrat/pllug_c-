using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public abstract class Passageway : IReadParam
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }

        public virtual void SetParamValue(Dictionary<string, double> keyValuePairs)
        {
            Width = keyValuePairs["Width"];
            Height = keyValuePairs["Height"];
        }
    }
}

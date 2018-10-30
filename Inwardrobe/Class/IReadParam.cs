using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    interface IReadParam
    {
        void SetParamValue(Dictionary<string, double> keyValuePairs);
    }
}

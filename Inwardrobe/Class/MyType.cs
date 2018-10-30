using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class MyType
    {
        public Type ValueType { set; get; }

        public MyType(Type type)
        {
            ValueType = type;
        }

        public override string ToString()
        {
            return ValueType.Name;
        }
    }
}

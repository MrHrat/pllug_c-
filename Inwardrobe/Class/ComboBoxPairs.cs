using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inwardrobe.Class
{
    public class ComboBoxPairs
    {
        public string Key { get; set; }
        public string Value
        {
            get
            {
                return Builder.GetPropertyValue(Obj, Key).ToString();
            }
            set
            {
                Builder.SetPropertyValue(Obj, Key, Convert.ToDouble(value));
            }
        }
        public object Obj { get; set; }

        public ComboBoxPairs(string key, object obj)
        {
            Key = key;
            Obj = obj;
        }
    }
}

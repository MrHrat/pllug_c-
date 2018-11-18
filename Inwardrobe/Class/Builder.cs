using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace Inwardrobe.Class
{
    public class Builder
    {
        private Passageway _passageway;
        private VolumetricBody _volumetricBody;        

        public Builder() { }
        public Builder(Passageway passageway, VolumetricBody volumetricBody)
        {
            _passageway = passageway;
            _volumetricBody = volumetricBody;
        }

        public string GetResult()
        {
            PassGate passGate = FactoryCollection.GetPassGate(_passageway, _volumetricBody);

            string ask = passGate.MoveTheGate();
            return ask != "" ? ask : "Will come to look for another way :(";
        }

        public static Type[] LoadSelectList(Type abstractType)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();            
            List<Type> ls = new List<Type>();

            for (int i = 0; i < assemblies.Length; i++)
            {
                Type[] types = assemblies[i].GetTypes();
                for (int j = 0; j < types.Length; j++)
                {
                    if (types[j].IsSubclassOf(abstractType))
                    {
                        ls.Add(types[j]);
                    }
                }                
            }

            return ls.ToArray();
        }

        public static ObservableCollection<ComboBoxPairs> LoadPropertyForm(object obj)
        {
            PropertyInfo[] myPropertyInfo = obj.GetType().GetProperties();
            ObservableCollection<ComboBoxPairs> ls = new ObservableCollection<ComboBoxPairs>();

            for (int i = 0; i < myPropertyInfo.Length; i++)
                if (myPropertyInfo[i].CanWrite)
                {
                    ls.Add(new ComboBoxPairs(myPropertyInfo[i].Name, obj));                    
                }

            return ls;
        }

        public static object GetPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperties()
               .Single(pi => pi.Name == propertyName)
               .GetValue(obj, null);
        }

        public static void SetPropertyValue(object obj, string propertyName, double value)
        {
            PropertyInfo prop = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
            }
        }        
    }
}

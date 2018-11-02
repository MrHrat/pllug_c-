using Inwardrobe.Views;
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

namespace Inwardrobe.Class
{
    public class Builder
    {
        private Passageway passageway;
        private VolumetricBody volumetricBody;
        private PassGate passGate;

        public Builder() { }

        public void SetBodyOrGate(StackPanel stackPanel, ComboBox comboBox)
        {
            Dictionary<string, double> keyValuePairs = new Dictionary<string, double>();
            foreach (VariablesBlock variablesBlock in stackPanel.Children)
            {
                keyValuePairs.Add(variablesBlock.NameValue, variablesBlock.Value);
            }

            if (FormatterServices.GetUninitializedObject((comboBox.SelectedItem as MyType).ValueType) is Passageway)
            {
                passageway = FormatterServices.GetUninitializedObject((comboBox.SelectedItem as MyType).ValueType) as Passageway;
                passageway.SetParamValue(keyValuePairs);
            }
            else if (FormatterServices.GetUninitializedObject((comboBox.SelectedItem as MyType).ValueType) is VolumetricBody)
            {
                volumetricBody = FormatterServices.GetUninitializedObject((comboBox.SelectedItem as MyType).ValueType) as VolumetricBody;
                volumetricBody.SetParamValue(keyValuePairs);
            }
        }

        public void GetResult(MetroWindow Mbox)
        {
            passGate = FactoryCollection.GetPassGate(passageway, volumetricBody);

            string ask = passGate.MoveTheGate();
            Mbox.ShowMessageAsync("We try to pack the " + passGate.VBody.GetType().Name, 
                ask != "" ? ask : "Will come to look for another way :(");
        }

        public static Type[] LoadSelectComboBox(Type abstractType)
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

        public static void LoadPropertyForm(StackPanel stackPanel, ComboBox comboBox)
        {
            PropertyInfo[] myPropertyInfo;
            Type myType = (comboBox.SelectedItem as MyType).ValueType;

            myPropertyInfo = myType.GetProperties();

            stackPanel.Children.Clear();

            for (int i = 0; i < myPropertyInfo.Length; i++)
                if (myPropertyInfo[i].CanWrite)
                    stackPanel.Children.Add(new VariablesBlock(myPropertyInfo[i].Name));
        }
    }
}

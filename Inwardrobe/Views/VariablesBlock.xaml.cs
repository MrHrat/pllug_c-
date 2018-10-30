using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inwardrobe.Views
{
    /// <summary>
    /// Логика взаимодействия для VariablesBlock.xaml
    /// </summary>
    public partial class VariablesBlock : UserControl
    {
        public string NameValue { set; get; }

        public double Value
        {
            get { return Convert.ToDouble(Xvalue.Text); }
            set { Xvalue.Text = value.ToString(); }
        }

        public VariablesBlock(string name)
        {
            NameValue = name;
            InitializeComponent();
        }
    }
}

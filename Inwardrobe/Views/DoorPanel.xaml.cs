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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Inwardrobe.Views
{
    /// <summary>
    /// Логика взаимодействия для DoorPanel.xaml
    /// </summary>
    public partial class DoorPanel : MetroContentControl
    {
        public DoorPanel()
        {
            InitializeComponent();
        }

        public double Dwidth
        {
            get => Convert.ToDouble(Dw.Text);
        }

        public double Dheight
        {
            get => Convert.ToDouble(Dh.Text);
        }
    }
}

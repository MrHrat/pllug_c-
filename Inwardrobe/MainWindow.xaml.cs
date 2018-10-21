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
using Inwardrobe.Class;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Inwardrobe
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Builder builder;

        public MainWindow()
        {
            InitializeComponent();
            builder = new Builder();
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                builder.SetPassageway(Passageway);
                builder.SetVolumetricBody(VolumetricBoby);
                builder.GetResult(this);
            }
            catch(FormatException ex)
            {
                this.ShowMessageAsync("Error!", "Invalid number format");
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync("Error!", ex.GetType().ToString());
            }
        }
    }
}

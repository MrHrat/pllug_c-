using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
using Inwardrobe.Views;
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

        public string Version
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public MainWindow()
        {
            InitializeComponent();
            builder = new Builder();
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {            
            try
            {                
                builder.SetBodyOrGate(passageway, selectPassageway);
                builder.SetBodyOrGate(volumetricBoby, selectVolumetricBody);
                builder.GetResult(this);
            }
            catch (FormatException ex)
            {
                this.ShowMessageAsync("Error!", "Invalid number format");
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync("Error!", ex.GetType().ToString());
            }
        }

        private void selectPassageway_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Builder.LoadPropertyForm(passageway, selectPassageway);
        }

        private void selectVolumetricBody_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Builder.LoadPropertyForm(volumetricBoby, selectVolumetricBody);
        }

        private void metroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Builder.LoadSelectComboBox(typeof(Passageway), selectPassageway);
            Builder.LoadSelectComboBox(typeof(VolumetricBody), selectVolumetricBody);
        }
    }
}

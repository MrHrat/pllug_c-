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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Inwardrobe
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private ApplicationViewModel ViewModel;

        public string Version
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new ApplicationViewModel();
            DataContext = ViewModel;
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            string ask = "";
            foreach (ComboBoxPairs cbp in ViewModel.paramPassageways)
            {
                ask += cbp.Key + " " + cbp.Value + "\n";
            }
            MessageBox.Show(ask);
            
            //MessageBox.Show(ViewModel.paramPassageways["Radius"].ToString());
            Arch arch = new Arch(10.0, 10.0);
            MessageBox.Show(arch.Height.ToString());
            double rez = (double)Builder.GetPropertyValue(arch, "Height");
            Builder.SetPropertyValue(arch, "Height", 101.0);
            rez = 101.0;
            MessageBox.Show(arch.Height.ToString());
        }

        private void selectPassageway_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ViewModel.LoadProperty();
        }

        private void selectVolumetricBody_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Builder.LoadPropertyForm(volumetricBoby, selectVolumetricBody.SelectedItem as Type);
            //MessageBox.Show(volumetricBoby.Children[0].ToString());
        }

        private void metroWindow_Loaded(object sender, RoutedEventArgs e)
        {            
            //selectPassageway.ItemsSource = Builder.LoadSelectComboBox(typeof(Passageway));
            //selectVolumetricBody.ItemsSource = Builder.LoadSelectComboBox(typeof(VolumetricBody));
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {            
            Builder builder = new Builder(ViewModel.SelectedPassageway, ViewModel.SelectedVolumetricBody);
            this.ShowMessageAsync("We try to pack", builder.GetResult());
        }

        private void metroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.LoadWork();
            ViewModel.Init();
        }

        private void metroWindow_Closed(object sender, EventArgs e)
        {
            ViewModel.SaveWork();
        }
    }
}

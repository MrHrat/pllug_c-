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

namespace Inwardrobe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public class ShapePlenum
    {
        double x;
        double y;
        double z;
        bool inMiddle;
        
        public double width
        {
            get => x;
            set => x = value;
        }

        public double height
        {
            get => y;
            set => y = value;
        }

        public double depth
        {
            get => z;
            set => z = value;
        }

        public bool InMiddle
        {
            get => inMiddle;
            set => inMiddle = value;
        }

        public ShapePlenum() : this(0.0, 0.0) { }

        public ShapePlenum(double x, double y, double z = 0.0, bool inMiddle = false)
        {
            this.x = x;
            this.y = y;
            this.z = z;

            this.inMiddle = inMiddle;
        }

        public bool PassThisDoor(ShapePlenum objIn)
        {
            if (!inMiddle)
            {
                if (x <= 0 || y <= 0) return false;
                                
                List<double> list = new List<double>();
                
                this.AddList(list);
                objIn.AddList(list);

                list.Sort();
                list.Reverse();
                
                if (list.FindLastIndex(value => value == x) == 4 || list.FindLastIndex(value => value == y) == 4)
                    return false;
                else if(list.FindLastIndex(value => value == x) >= 2 && list.FindLastIndex(value => value == y) >= 2)
                    return false;
                else
                    return true;                
            }
            else return false;
        }

        public void AddList(List<double> list)
        {
            list.Add(x);
            list.Add(y);
            if(z > 0.0)
                list.Add(z);
        }
    }

    public class Bilder
    {
        ShapePlenum doorOpen;
        ShapePlenum wardrobe;

        public Bilder() { }

        public void setdoorOpen(TextBox x, TextBox y)
        {
            doorOpen = new ShapePlenum(Convert.ToDouble(x.Text), Convert.ToDouble(y.Text));
        }

        public void setwardrobe(TextBox x, TextBox y, TextBox z)
        {
            wardrobe = new ShapePlenum(Convert.ToDouble(x.Text), Convert.ToDouble(y.Text), Convert.ToDouble(z.Text), true);
        }

        public void getresult(MetroWindow Mbox)
        {
            String result;
            if (doorOpen.PassThisDoor(wardrobe)) result = "All is well, it's gone! ;)";
            else result = "Will come to look for another way :(";
            Mbox.ShowMessageAsync("We try to pack the wardrobe", result);
        }
    }
    
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Runs_Click(object sender, RoutedEventArgs e)
        {
            Bilder ob = new Bilder();

            ob.setdoorOpen(Dx, Dy);
            ob.setwardrobe(Wx, Wy, Wz);
            
            ob.getresult(this);
        }
    }
}

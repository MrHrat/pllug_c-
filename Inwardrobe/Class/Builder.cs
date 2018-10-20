using Inwardrobe.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Inwardrobe.Class
{
    public class Builder
    {
        private object passageway;
        private object volumetricBody;
        private PassGate passGate;

        public Builder() { }

        public void SetPassageway(TabControl items)
        {
            var tab = items.SelectedItem as TabItem;            
            switch (tab.Header.ToString())
            {
                case "Door":
                    var Dp = tab.Content as DoorPanel;
                    passageway = new Door(Dp.Dwidth, Dp.Dheight);
                    break;
                case "Arch":
                    var Ap = tab.Content as ArchPanel;
                    passageway = new Door(Ap.Aradius * 2.0, Ap.Aheight);
                    break;
            }
        }

        public void SetVolumetricBody(TabControl items)
        {
            var tab = items.SelectedItem as TabItem;            
            switch (tab.Header.ToString())
            {
                case "Wardrobe":
                    var Ds = tab.Content as StandardPanel;
                    volumetricBody = new Wardrobe(Ds.Swidth, Ds.Sheight, Ds.Sdepth);
                    break;
                case "Tub":
                    var Ap = tab.Content as ArchPanel;
                    volumetricBody = new Tub(Ap.Aradius, Ap.Aheight);
                    break;
                case "Bullet":
                    var Bp = tab.Content as BulletPanel;
                    volumetricBody = new Bullet(Bp.Bradius);
                    break;
            }
        }

        public void GetResult(MetroWindow Mbox)
        {
            var pway = passageway is Door ? passageway as Door : null;
            if (volumetricBody is Wardrobe)
            {
                var vboby = volumetricBody as Wardrobe;
                passGate = FactoryCollection.GetPassGate(pway, vboby);
            }
            else if (volumetricBody is Tub)
            {
                var vboby = volumetricBody as Tub;
                passGate = FactoryCollection.GetPassGate(pway, vboby);
            }
            else if (volumetricBody is Bullet)
            {
                var vboby = volumetricBody as Bullet;
                passGate = FactoryCollection.GetPassGate(pway, vboby);
            }

            string ask = passGate.MoveTheGate();
            Mbox.ShowMessageAsync("We try to pack the " + passGate.VBody.GetType().ToString().Substring(passGate.VBody.GetType().ToString().LastIndexOf('.') + 1), 
                ask != "" ? ask : "Will come to look for another way :(");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace Inwardrobe.Class
{
    [Serializable]
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        #region Passageway definition
        public ObservableCollection<Passageway> passageways { get; set; }

        [XmlIgnore]
        private Passageway _selectedPassageway;
        [XmlIgnore]
        public Passageway SelectedPassageway
        {
            get { return _selectedPassageway; }
            set
            {
                _selectedPassageway = value;
                paramPassageways = Builder.LoadPropertyForm(_selectedPassageway);
                OnPropertyChanged("SelectedPassageway");
            }
        }

        [XmlIgnore]
        private ObservableCollection<ComboBoxPairs> _paramPassageways;
        [XmlIgnore]
        public ObservableCollection<ComboBoxPairs> paramPassageways
        {
            get { return _paramPassageways; }
            set
            {
                _paramPassageways = value;                
                OnPropertyChanged("paramPassageways");
            }
        }

        private int _selectedIndexPassageways;
        public int SelectedIndexPassageways
        {
            get { return _selectedIndexPassageways; }
            set
            {
                _selectedIndexPassageways = value;
                OnPropertyChanged("SelectedIndexPassageways");
            }
        }
        #endregion

        #region VolumetricBody definition
        public ObservableCollection<VolumetricBody> volumetricBodies { get; set; }

        [XmlIgnore]
        private VolumetricBody _selectedVolumetricBody;
        [XmlIgnore]
        public VolumetricBody SelectedVolumetricBody
        {
            get { return _selectedVolumetricBody; }
            set
            {
                _selectedVolumetricBody = value;
                paramVolumetricBody = Builder.LoadPropertyForm(SelectedVolumetricBody);
                OnPropertyChanged("SelectedVolumetricBody");
            }
        }

        [XmlIgnore]
        private ObservableCollection<ComboBoxPairs> _paramVolumetricBody;
        [XmlIgnore]
        public ObservableCollection<ComboBoxPairs> paramVolumetricBody
        {
            get { return _paramVolumetricBody; }
            set
            {
                _paramVolumetricBody = value;
                OnPropertyChanged("paramVolumetricBody");
            }
        }

        private int _selectedIndexVolumetricBody;
        public int SelectedIndexVolumetricBody
        {
            get { return _selectedIndexVolumetricBody; }
            set
            {
                _selectedIndexVolumetricBody = value;
                OnPropertyChanged("SelectedIndexVolumetricBody");
            }
        }
        #endregion

        public ApplicationViewModel()
        {
            passageways = new ObservableCollection<Passageway>();
            volumetricBodies = new ObservableCollection<VolumetricBody>();
        }

        public void Init()
        {
            if (passageways.Count == 0 && volumetricBodies.Count == 0)
            {
                SelectedPassageway = (passageways = InitObservableCollection<Passageway>())[0];
                SelectedIndexPassageways = 0;
                SelectedVolumetricBody = (volumetricBodies = InitObservableCollection<VolumetricBody>())[0];
                SelectedIndexVolumetricBody = 0;
            }
        }

        public void SaveWork()
        {
            SmartTools.SaveXML(this, "./ApplicationViewModel.xml");
        }

        public void LoadWork()
        {
            try
            {
                ApplicationViewModel temp = SmartTools.OpenXML<ApplicationViewModel>("./ApplicationViewModel.xml");

                passageways = new ObservableCollection<Passageway>(temp.passageways);                
                volumetricBodies = new ObservableCollection<VolumetricBody>(temp.volumetricBodies);

                SelectedIndexPassageways = temp._selectedIndexPassageways;
                SelectedIndexVolumetricBody = temp._selectedIndexVolumetricBody;                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        static ObservableCollection<T> InitObservableCollection<T>() where T : class
        {
            ObservableCollection<T> ts = new ObservableCollection<T>();
            foreach (Type mytype in Builder.LoadSelectList(typeof(T)))
            {
                ts.Add(FormatterServices.GetUninitializedObject(mytype) as T);
            }            
            return ts;
        }
    }    
}

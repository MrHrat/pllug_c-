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

namespace Inwardrobe.Class
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        #region Passageway definition
        public ObservableCollection<Passageway> passageways { get; set; }

        private Passageway _selectedPassageway;
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

        private ObservableCollection<ComboBoxPairs> _paramPassageways;
        public ObservableCollection<ComboBoxPairs> paramPassageways
        {
            get { return _paramPassageways; }
            set
            {
                _paramPassageways = value;                
                OnPropertyChanged("paramPassageways");
            }
        }
        #endregion

        #region VolumetricBody definition
        public ObservableCollection<VolumetricBody> volumetricBodies { get; set; }

        private VolumetricBody selectedVolumetricBody;
        public VolumetricBody SelectedVolumetricBody
        {
            get { return selectedVolumetricBody; }
            set
            {
                selectedVolumetricBody = value;
                paramVolumetricBody = Builder.LoadPropertyForm(SelectedVolumetricBody);
                OnPropertyChanged("SelectedVolumetricBody");
            }
        }

        private ObservableCollection<ComboBoxPairs> _paramVolumetricBody;
        public ObservableCollection<ComboBoxPairs> paramVolumetricBody
        {
            get { return _paramVolumetricBody; }
            set
            {
                _paramVolumetricBody = value;
                OnPropertyChanged("paramVolumetricBody");
            }
        }
        #endregion

        public ApplicationViewModel()
        {
            SelectedPassageway = (passageways = InitObservableCollection<Passageway>())[0];
            SelectedVolumetricBody = (volumetricBodies = InitObservableCollection<VolumetricBody>())[0];
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

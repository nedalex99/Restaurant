using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.Models.BusinessLogicLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.ViewModels
{
    public class NoAccountViewModel : BaseViewModel
    {
        private MeniuBLL meniuBLL = new MeniuBLL();
        private AlergeniBLL alergeniBLL = new AlergeniBLL();
        private PreparateBLL preparateBLL = new PreparateBLL();
        private MeniuriCuPreparateBLL meniuriCuPreparateBLL = new MeniuriCuPreparateBLL();

        private ObservableCollection<Meniu> _meniuri;
        public ObservableCollection<Meniu> Meniuri
        {
            get { return _meniuri; }
            set
            {
                _meniuri = value;
                OnPropertyChanged("Meniuri");
            }
        }

        private ObservableCollection<Preparate> _preparate;
        public ObservableCollection<Preparate> Preparate
        {
            get { return _preparate; }
            set
            {
                _preparate = value;
                OnPropertyChanged("Preparate");
            }
        }


        private ObservableCollection<MeniuriCuPreparate> _preparateDinMeniuri;
        public ObservableCollection<MeniuriCuPreparate> PreparateDinMeniuri
        {
            get { return _preparateDinMeniuri; }
            set
            {
                _preparateDinMeniuri = value;
                OnPropertyChanged("PreparateDinMeniuri");
            }
        }

        private Dictionary<Meniu, ObservableCollection<MeniuriCuPreparate>> _meniuriCuPreparate;
        public Dictionary<Meniu, ObservableCollection<MeniuriCuPreparate>> MeniuriCuPreparate
        {
            get { return _meniuriCuPreparate; }
            set
            {
                _meniuriCuPreparate = value;
                OnPropertyChanged("MeniuriCuPreparate");
            }
        }

        private ObservableCollection<Alergeni> _alergeni;

        private ObservableCollection<Preparate> _preparateDinAlergeni;

        private Dictionary<Alergeni, ObservableCollection<Preparate>> _preparateCuAlergeni;
        public Dictionary<Alergeni, ObservableCollection<Preparate>> PreparateCuAlergeni
        {
            get { return _preparateCuAlergeni; }
            set
            {
                _preparateCuAlergeni = value;
                OnPropertyChanged("PreparateCuAlergeni");
            }
        }



        public NoAccountViewModel()
        {
            _meniuri = meniuBLL.GetAllMeniu();
            _preparate = preparateBLL.GetAllPreparate();
            _alergeni = alergeniBLL.GetAllAlergeni();
            _meniuriCuPreparate = new Dictionary<Meniu, ObservableCollection<MeniuriCuPreparate>>();
            _preparateCuAlergeni = new Dictionary<Alergeni, ObservableCollection<Preparate>>();
            AddPreparateDinMeniuri();
            AddPreparateDinAlergeni();
        }

        private Meniu _selectedMeniu;
        public Meniu SelectedMeniu
        {
            get { return _selectedMeniu; }
            set
            {
                _selectedMeniu = value;
                OnPropertyChanged("SelectedMeniu");
            }
        }

        public void AddPreparateDinMeniuri()
        {
            foreach (var menu in _meniuri)
            {
                _preparateDinMeniuri = meniuriCuPreparateBLL.GetAllMeniuriCuPreparate(menu);
                _meniuriCuPreparate.Add(menu, _preparateDinMeniuri);
            }
        }

        public void AddPreparateDinAlergeni()
        {
            _preparateDinAlergeni = new ObservableCollection<Preparate>();
            foreach (var alergen in _alergeni)
            {
                PreparateBLL preparateBLL = new PreparateBLL();
                _preparateDinAlergeni = preparateBLL.GetPreparatForAlergen(alergen);
                _preparateCuAlergeni.Add(alergen, _preparateDinAlergeni);
            }
        }
    }
}

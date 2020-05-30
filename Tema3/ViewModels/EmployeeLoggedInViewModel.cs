using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.Commands;
using Tema3.Models.BusinessLogicLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.ViewModels
{
    public class EmployeeLoggedInViewModel : BaseViewModel
    {
        private CategoriiDePreparateBLL categoriiDePreparateBLL = new CategoriiDePreparateBLL();
        private PreparateBLL preparateBLL = new PreparateBLL();
        private MeniuBLL meniuBLL = new MeniuBLL();
        private AlergeniBLL alergeniBLL = new AlergeniBLL();
        private MeniuriCuPreparateBLL meniuriCuPreparateBLL = new MeniuriCuPreparateBLL();

        private ObservableCollection<CategoriiDePreparate> _categorii;
        public ObservableCollection<CategoriiDePreparate> Categorii
        {
            get
            {
                return _categorii;
            }
            set
            {
                _categorii = value;
                OnPropertyChanged("Categorii");
            }
        }

        private ObservableCollection<Preparate> _preparate;
        public ObservableCollection<Preparate> Preparate
        {
            get
            {
                return _preparate;
            }
            set
            {
                _preparate = value;
                OnPropertyChanged("Preparate");
            }
        }

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

        private ObservableCollection<Alergeni> _alergeni;
        public ObservableCollection<Alergeni> Alergeni
        {
            get
            {
                return _alergeni;
            }
            set
            {
                _alergeni = value;
                OnPropertyChanged("Alergeni");
            }
        }

        private ObservableCollection<MeniuriCuPreparate> _meniuriCuPreparate;
        public ObservableCollection<MeniuriCuPreparate> MeniuriCuPreparate
        {
            get { return _meniuriCuPreparate; }
            set
            {
                _meniuriCuPreparate = value;
                OnPropertyChanged("MeniuriCuPreparate");
            }
        }

        private Dictionary<string, ObservableCollection<MeniuriCuPreparate>> _preparateDinMeniuri = new Dictionary<string, ObservableCollection<MeniuriCuPreparate>>();
        public Dictionary<string, ObservableCollection<MeniuriCuPreparate>> PreparateDinMeniuri
        {
            get
            {
                return _preparateDinMeniuri;
            }
            set
            {
                _preparateDinMeniuri = value;
                OnPropertyChanged("PreparateDinMeniuri");
            }
        }

        public EmployeeLoggedInViewModel()
        {
            _categorii = categoriiDePreparateBLL.GetAllCategorii();
            _preparate = preparateBLL.GetAllPreparate();
            _meniuri = meniuBLL.GetAllMeniu();
            _alergeni = alergeniBLL.GetAllAlergeni();
            //_meniuriCuPreparate = meniuriCuPreparateBLL.GetAllMeniuriCuPreparate();
            AddPreparateDinMeniuri();

            AddCategorieCommand = new AddCategorieCommand(this);
            DeleteCategorieCommand = new DeleteCategorieCommand(this);

            AddPreparatCommand = new AddPreparatCommand(this);
            DeletePreparatCommand = new DeletePreparatCommand(this);

            AddMeniuCommand = new AddMeniuCommand(this);
            DeleteMeniuCommand = new DeleteMeniuCommand(this);

            AddAlergeniCommand = new AddAlergeniCommand(this);
            DeleteAlergeniCommand = new DeleteAlergeniCommand(this);

            GetPreparateDinMeniuriCommand = new GetPreparateDinMeniuriCommand(this);
        }


        #region CategoriiDePreparate

        private string _nume;
        public string Nume
        {
            get { return _nume; }
            set
            {
                _nume = value;
                OnPropertyChanged("Nume");
            }
        }

        private CategoriiDePreparate _selectedCategorie;
        public CategoriiDePreparate SelectedCategorie
        {
            get { return _selectedCategorie; }
            set
            {
                _selectedCategorie = value;
                OnPropertyChanged("SelectedCategorie");
            }
        }

        public ICommand AddCategorieCommand { get; private set; }
        public void AddCategorie()
        {
            _categorii.Add(new CategoriiDePreparate
            {
                Nume = Nume
            });
            categoriiDePreparateBLL.AddCategorie(new CategoriiDePreparate
            {
                Nume = Nume
            });
        }

        public ICommand DeleteCategorieCommand { get; private set; }
        public void DeleteCategorie()
        {
            categoriiDePreparateBLL.DeleteCategorie(SelectedCategorie);
            for (int i = 0; i < _categorii.Count; i++)
            {
                if (_categorii[i].Nume == SelectedCategorie.Nume)
                {
                    _categorii.RemoveAt(i);
                    break;
                }
            }
        }

        #endregion

        #region Preparat

        private string _denumirePreparat;
        public string DenumirePreparat
        {
            get { return _denumirePreparat; }
            set
            {
                _denumirePreparat = value;
                OnPropertyChanged("Denumire");
            }
        }

        private decimal _pretPreparat;
        public decimal PretPreparat
        {
            get { return _pretPreparat; }
            set
            {
                _pretPreparat = value;
                OnPropertyChanged("Pret");
            }
        }

        private int _cantitatePreparat;
        public int CantitatePreparat
        {
            get { return _cantitatePreparat; }
            set
            {
                _cantitatePreparat = value;
                OnPropertyChanged("Cantitate");
            }
        }

        private int _cantitateTotalaPreparat;
        public int CantitateTotalaPreparat
        {
            get { return _cantitateTotalaPreparat; }
            set
            {
                _cantitateTotalaPreparat = value;
                OnPropertyChanged("CantitateTotala");
            }
        }

        private int _categorieIdPreparat;
        public int CategorieIdPreparat
        {
            get { return _categorieIdPreparat; }
            set
            {
                _categorieIdPreparat = value;
                OnPropertyChanged("CategorieId");
            }
        }

        private Preparate _selectedPreparat;
        public Preparate SelectedPreparat
        {
            get { return _selectedPreparat; }
            set
            {
                _selectedPreparat = value;
                OnPropertyChanged("SelectedPreparat");
            }
        }

        public ICommand AddPreparatCommand { get; private set; }
        public void AddPreparat()
        {
            preparateBLL.AddPreparat(new Preparate
            {
                Denumire = DenumirePreparat,
                Pret = PretPreparat,
                Cantitate = CantitatePreparat,
                CantitateTotala = CantitateTotalaPreparat,
                CategorieId = CategorieIdPreparat
            });
            _preparate.Add(new Preparate
            {
                Denumire = DenumirePreparat,
                Pret = PretPreparat,
                Cantitate = CantitatePreparat,
                CantitateTotala = CantitateTotalaPreparat,
                CategorieId = CategorieIdPreparat
            });
        }

        public ICommand DeletePreparatCommand { get; private set; }
        public void DeletePreparat()
        {
            preparateBLL.DeletePreparat(SelectedPreparat);
            for (int i = 0; i < _preparate.Count; i++)
            {
                if (_preparate[i].Denumire == SelectedPreparat.Denumire)
                {
                    _preparate.RemoveAt(i);
                    break;
                }
            }
        }

        #endregion

        #region Meniuri

        private string _denumireMeniu;
        public string DenumireMeniu
        {
            get { return _denumireMeniu; }
            set
            {
                _denumireMeniu = value;
                OnPropertyChanged("Denumire");
            }
        }

        private decimal _pretMeniu;
        public decimal PretMeniu
        {
            get { return _pretMeniu; }
            set
            {
                _pretMeniu = value;
                OnPropertyChanged("Pret");
            }
        }

        private int _categorieIdMeniu;
        public int CategorieIdMeniu
        {
            get { return _categorieIdMeniu; }
            set
            {
                _categorieIdMeniu = value;
                OnPropertyChanged("CategorieId");
            }
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

        public ICommand AddMeniuCommand { get; private set; }
        public void AddMeniu()
        {
            meniuBLL.AddMeniu(new Meniu
            {
                Denumire = DenumireMeniu,
                Pret = PretMeniu,
                CategorieId = CategorieIdMeniu
            });
            _meniuri.Add(new Meniu
            {
                Denumire = DenumireMeniu,
                Pret = PretMeniu,
                CategorieId = CategorieIdMeniu
            });
        }

        public ICommand DeleteMeniuCommand { get; private set; }
        public void DeleteMeniu()
        {
            meniuBLL.DeleteMeniu(SelectedMeniu);
            for (int i = 0; i < _meniuri.Count; i++)
            {
                if (_meniuri[i].Denumire == SelectedMeniu.Denumire)
                {
                    _meniuri.RemoveAt(i);
                    break;
                }
            }
        }

        #endregion

        #region MeniuriCuPreparate

        private string _meniuDenumire;
        public string MeniuDenumire
        {
            get { return _meniuDenumire; }
            set
            {
                _meniuDenumire = value;
                OnPropertyChanged("MeniuDenumire");
            }
        }

        private string _preparatDenumire;
        public string PreparatDenumire
        {
            get { return _preparatDenumire; }
            set
            {
                _preparatDenumire = value;
                OnPropertyChanged("PreparatDenumire");
            }
        }

        private int? _cantitate;
        public int? Cantitate
        {
            get { return _cantitate; }
            set
            {
                _cantitate = value;
                OnPropertyChanged("Cantitate");
            }
        }

        public ICommand GetPreparateDinMeniuriCommand { get; private set; }

        public void AddPreparateDinMeniuri()
        {
            foreach(var menu in _meniuri)
            {
                _meniuriCuPreparate = meniuriCuPreparateBLL.GetAllMeniuriCuPreparate(menu);
                _preparateDinMeniuri.Add(menu.Denumire, _meniuriCuPreparate);
            }
        }

        #endregion

        #region Alergeni

        private string _denumireAlergeni;
        public string DenumireAlergeni
        {
            get { return _denumireAlergeni; }
            set
            {
                _denumireAlergeni = value;
                OnPropertyChanged("DenumireAlergeni");
            }
        }

        private Alergeni _selectedAlergeni;
        public Alergeni SelectedAlergeni
        {
            get { return _selectedAlergeni; }
            set
            {
                _selectedAlergeni = value;
                OnPropertyChanged("SelectedAlergeni");
            }
        }

        public ICommand AddAlergeniCommand { get; private set; }
        public void AddAlergeni()
        {
            alergeniBLL.AddAlergeni(new Alergeni
            {
                Denumire = DenumireAlergeni
            });
            _alergeni.Add(new Alergeni
            {
                Denumire = DenumireAlergeni
            });
        }

        public ICommand DeleteAlergeniCommand { get; private set; }
        public void DeleteAlergeni()
        {
            alergeniBLL.DeleteAlergeni(SelectedAlergeni);
            for (int i = 0; i < _alergeni.Count; i++)
            {
                if (_alergeni[i].Denumire == SelectedAlergeni.Denumire)
                {
                    _alergeni.RemoveAt(i);
                    break;
                }
            }
        }

        #endregion

    }
}

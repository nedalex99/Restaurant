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

        public EmployeeLoggedInViewModel()
        {
            _categorii = categoriiDePreparateBLL.GetAllCategorii();
            _preparate = preparateBLL.GetAllPreparate();
            _meniuri = meniuBLL.GetAllMeniu();
            AddCategorieCommand = new AddCategorieCommand(this);
            DeleteCategorieCommand = new DeleteCategorieCommand(this);

            AddPreparatCommand = new AddPreparatCommand(this);

            AddMeniuCommand = new AddMeniuCommand(this);
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

        #endregion

    }
}

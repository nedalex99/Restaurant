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
    public class ClientLoggedInViewModel : BaseViewModel
    {
        private ClientBLL clientBLL = new ClientBLL();
        private MeniuBLL meniuBLL = new MeniuBLL();
        private PreparateBLL preparateBLL = new PreparateBLL();
        private PreparateComandateBLL preparateComandateBLL = new PreparateComandateBLL();
        private ComenziBLL comenziBLL = new ComenziBLL();

        private ObservableCollection<Comenzi> _comenzi;
        public ObservableCollection<Comenzi> Comenzi
        {
            get { return _comenzi; }
            set
            {
                _comenzi = value;
                OnPropertyChanged("Comenzi");
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

        private ObservableCollection<PreparateComandate> _preparateComandate;
        public ObservableCollection<PreparateComandate> PreparateComandate
        {
            get { return _preparateComandate; }
            set
            {
                _preparateComandate = value;
                OnPropertyChanged("PreparateComandate");
            }
        }

        private ObservableCollection<Preparate> _preparateAdaugateInComanda = new ObservableCollection<Preparate>();
        public ObservableCollection<Preparate> PreparateAdaugateInComanda
        {
            get { return _preparateAdaugateInComanda; }
            set
            {
                _preparateAdaugateInComanda = value;
                OnPropertyChanged("PreparateAdaugateInComanda");
            }
        }

        private ObservableCollection<Meniu> _meniuriAdaugateInComanda = new ObservableCollection<Meniu>();
        public ObservableCollection<Meniu> MeniuriAdaugateInComanda
        {
            get { return _meniuriAdaugateInComanda; }
            set
            {
                _meniuriAdaugateInComanda = value;
                OnPropertyChanged("MeniuriAdaugateInComanda");
            }
        }



        private ObservableCollection<Preparate> _preparateDinMeniuri;

        private Dictionary<Meniu, ObservableCollection<Preparate>> _preparateCuMeniuri;
        public Dictionary<Meniu, ObservableCollection<Preparate>> PreparateCuMeniuri
        {
            get { return _preparateCuMeniuri; }
            set
            {
                _preparateCuMeniuri = value;
                OnPropertyChanged("PreparateCuMeniuri");
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

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public ClientLoggedInViewModel()
        {
            _meniuri = meniuBLL.GetAllMeniu();
            _preparate = preparateBLL.GetAllPreparate();
            _preparateCuMeniuri = new Dictionary<Meniu, ObservableCollection<Preparate>>();
            _preparateComandate = preparateComandateBLL.GetAllPreparateComandate();
            AddPreparateInMeniu();

            AddMeniuInComandaCommand = new AddMeniuInComandaCommand(this);
            AddPreparatInComand = new AddPreparatInComandaCommand(this);
            PlaseazaComandaCommand = new PlaseazaComandaCommand(this);
        }

        #region Meniu

        private KeyValuePair<Meniu, ObservableCollection<Preparate>> _selectedMeniu;
        public KeyValuePair<Meniu, ObservableCollection<Preparate>> SelectedMeniu
        {
            get { return _selectedMeniu; }
            set
            {
                _selectedMeniu = value;
                OnPropertyChanged("SelectedMeniu");
            }
        }

        #endregion

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

        public void AddPreparateInMeniu()
        {
            _preparateDinMeniuri = new ObservableCollection<Preparate>();
            foreach (var menu in _meniuri)
            {
                _preparateDinMeniuri = preparateBLL.GetPreparatForMeniu(menu);
                _preparateCuMeniuri.Add(menu, _preparateDinMeniuri);
            }
        }

        public ICommand AddMeniuInComandaCommand { get; private set; }
        public void AddMeniuInComanda()
        {
            _meniuriAdaugateInComanda.Add(SelectedMeniu.Key);
        }

        public ICommand AddPreparatInComand { get; private set; }
        public void AddComandaInMeniu()
        {
            _preparateAdaugateInComanda.Add(SelectedPreparat);
        }

        public ICommand PlaseazaComandaCommand { get; set; }
        public void PlaseazaComanda()
        {
            ClientBLL clientBLL = new ClientBLL();
            var client = clientBLL.GetClientWithEmailAndPassword(Email, Password);

            comenziBLL.AddComanda(new Comenzi()
            {
                ClientId = client.Id
            });

            var comanda = comenziBLL.GetComandaIdForClientId(client);
            
            foreach(var prep in _preparateAdaugateInComanda)
            {
                //preparateBLL.AddPreparatInComanda(comanda, prep, 1);
                preparateComandateBLL.AddPreparatComandate(comanda, prep, 1);
            }

            foreach(var menu in _meniuriAdaugateInComanda)
            {
                meniuBLL.AddMeniuInComanda(comanda, menu, 1);
            }

        }

    }
}

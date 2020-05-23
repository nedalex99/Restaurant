using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.Commands;
using Tema3.Models;
using Tema3.Models.BusinessLogicLayer;
using Tema3.Models.DataAccesLayer;
using Tema3.Models.EntityLayer;
using Tema3.Views;

namespace Tema3.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ClientBLL clientBLL = new ClientBLL();
        private EmployeeBLL employeBLL = new EmployeeBLL();
        private Client _user;
        private SignUpAsClientViewModel _signUpClientViewModel;
        private SignUpAsEmployeeViewModel _signUpEmployeeViewModel;
        private EmployeeLoggedInViewModel _userLoggedInViewModel;
        private ObservableCollection<Client> _users = new ObservableCollection<Client>();

        public LoginViewModel()
        {
            _signUpClientViewModel = new SignUpAsClientViewModel();
            _signUpEmployeeViewModel = new SignUpAsEmployeeViewModel();
            _userLoggedInViewModel = new EmployeeLoggedInViewModel();
            GoToSignUpAsClientCommand = new GoToLogUpClientCommand(this);
            GoToSignUpAsEmployeeCommand = new GoToLogUpEmployeeCommand(this);
            LogInClientCommand = new LogInClientCommand(this);
            LogInEmployeeCommand = new LogInEmployeeCommand(this);
            ContinueWithoutLoggingCommand = new ContinueWithoutLoggingCommand(this);
        }

        public Client User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }

        public string Email
        {
            get; set;
        }

        public string Parola
        {
            get; set;
        }

        public ObservableCollection<Client> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }

        public ICommand GoToSignUpAsClientCommand
        {
            get;
            private set;
        }

        public void GoToSignUpClient()
        {
            SignUpAsClientView view = new SignUpAsClientView();
            view.DataContext = _signUpClientViewModel;
            view.ShowDialog();
        }

        public ICommand GoToSignUpAsEmployeeCommand
        {
            get;
            private set;
        }

        public void GoToSignUpEmployee()
        {
            SignUpAsEmployeeView view = new SignUpAsEmployeeView();
            view.DataContext = _signUpEmployeeViewModel;
            view.ShowDialog();
        }

        public ICommand LogInClientCommand
        {
            get; private set;
        }

        public void LogInAsClient()
        {
            if (clientBLL.GetClientWithEmailAndPassword(Email, Parola))
            {
                EmployeeLoggedInView view = new EmployeeLoggedInView();
                view.DataContext = _userLoggedInViewModel;
                view.ShowDialog();
            }
        }

        public ICommand LogInEmployeeCommand
        {
            get;
            private set;
        }

        public void LogInAsEmployee()
        {
            if (employeBLL.GetEmployeeWithEmailAndPassword(Email, Parola))
            {
                EmployeeLoggedInView view = new EmployeeLoggedInView();
                view.DataContext = _userLoggedInViewModel;
                view.ShowDialog();
            }
        }

        public ICommand ContinueWithoutLoggingCommand
        {
            get;
            private set;
        }

        public void ContinueWithoutLogging()
        {
            EmployeeLoggedInView view = new EmployeeLoggedInView();
            view.DataContext = _userLoggedInViewModel;
            view.ShowDialog();
        }

    }
}

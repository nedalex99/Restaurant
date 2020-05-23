using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.ViewModels;

namespace Tema3.Commands
{
    public class GoToLogUpClientCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LoginViewModel _logInViewModel;

        public GoToLogUpClientCommand(LoginViewModel logInViewModel)
        {
            this._logInViewModel = logInViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _logInViewModel.GoToSignUpClient();
        }
    }
}

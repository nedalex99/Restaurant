using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.ViewModels;

namespace Tema3.Commands
{
    public class GoToLogUpEmployeeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LoginViewModel _viewModel;

        public GoToLogUpEmployeeCommand(LoginViewModel signUpViewModel)
        {
            this._viewModel = signUpViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.GoToSignUpEmployee();
        }
    }
}

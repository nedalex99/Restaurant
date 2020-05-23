using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Tema3.ViewModels;

namespace Tema3.Commands
{
    public class LogInClientCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LoginViewModel _viewModel;

        public LogInClientCommand(LoginViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            //return String.IsNullOrEmpty(_viewModel.User.Error);
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.LogInAsClient();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.ViewModels;

namespace Tema3.Commands
{
    public class AddPreparatInComandaCommand : ICommand
    {
        private ClientLoggedInViewModel _viewModel;

        public AddPreparatInComandaCommand(ClientLoggedInViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.AddComandaInMeniu();
        }
    }
}

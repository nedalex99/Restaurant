using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.Commands;
using Tema3.Models.BusinessLogicLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.ViewModels
{
    public class SignUpAsEmployeeViewModel : BaseViewModel
    {
        private EmployeeBLL employeeBLL = new EmployeeBLL();

        public SignUpAsEmployeeViewModel()
        {
            LogUpCommand = new LogUpEmployeeCommand(this);
        }

        public string Nume
        {
            get; set;
        }

        public string Prenume
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string Telefon
        {
            get; set;
        }

        public string Parola
        {
            get; set;
        }

        public ICommand LogUpCommand
        {
            get;
            private set;
        }

        public void AddEmployee()
        {
            employeeBLL.AddEmployee(new Employee()
            {
                Id = 3,
                Nume = Nume,
                Prenume = Prenume,
                Email = Email,
                Telefon = Telefon,
                Password = Parola
            });
        }
    }
}

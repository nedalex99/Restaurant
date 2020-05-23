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
    public class SignUpAsClientViewModel : BaseViewModel
    {
        private ClientBLL clientBLL = new ClientBLL();

        public SignUpAsClientViewModel()
        {
            LogUpCommand = new LogUpClientCommand(this);
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

        public string Adresa
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

        public void AddClient()
        {
            clientBLL.AddClient(new Client()
            {
                Id = 3,
                Nume = Nume,
                Prenume = Prenume,
                Email = Email,
                Telefon = Telefon,
                Adresa = Adresa,
                Password = Parola
            });
        }
    }
}

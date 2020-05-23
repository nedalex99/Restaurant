using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.Models.EntityLayer;

namespace Tema3.Models.EntityLayer
{
    public class Client : BasePropertyChanged
    {
        private int? _id;
        public int? Id 
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _nume;
        public string Nume
        {
            get
            {
                return _nume;
            }
            set
            {
                _nume = value;
                OnPropertyChanged("Nume");
            }
        }

        private string _prenume;
        public string Prenume
        {
            get => _prenume;
            set
            {
                _prenume = value;
                OnPropertyChanged("Prenume");
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _telefon;
        public string Telefon { get => _telefon; 
            set
            { 
                _telefon = value;
                OnPropertyChanged("Email");
            } 
        }

        private string _adresa;
        public string Adresa { get => _adresa;
            set
            {
                _adresa = value;
                OnPropertyChanged("Adresa");
            }
        }

        private string _password;
        public string Password { get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        //public User(int id, string name, string prenume, string email, string telefon, string adresa, string password)
        //{
        //    _id = id;
        //    _name = name;
        //    _prenume = prenume;
        //    _email = email;
        //    _telefon = telefon;
        //    _adresa = adresa;
        //    _password = password;
        //}


        //public string Error
        //{
        //    get;
        //    private set;
        //}

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        if (columnName == "Name")
        //        {
        //            if (String.IsNullOrEmpty(Name))
        //            {
        //                Error = "Name cannot be null or empty!";
        //            }
        //            else
        //            {
        //                Error = null;
        //            }
        //        }
        //        return Error;
        //    }
        //}
    }
}

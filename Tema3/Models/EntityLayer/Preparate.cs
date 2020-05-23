using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3.Models.EntityLayer
{
    public class Preparate : BasePropertyChanged
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _denumire;

        public string Denumire
        {
            get { return _denumire; }
            set
            {
                _denumire = value;
                OnPropertyChanged("Denumire");
            }
        }

        private decimal? _pret;

        public decimal? Pret
        {
            get { return _pret; }
            set
            {
                _pret = value;
                OnPropertyChanged("Pret");
            }
        }

        private int? _cantitate;

        public int? Cantitate
        {
            get { return _cantitate; }
            set
            {
                _cantitate = value;
                OnPropertyChanged("Cantitate");
            }
        }

        private int? _cantitateTotala;

        public int? CantitateTotala
        {
            get { return _cantitateTotala; }
            set
            {
                _cantitateTotala = value;
                OnPropertyChanged("CantitateTotala");
            }
        }

        private int? _categorieId;

        public int? CategorieId
        {
            get { return _categorieId; }
            set
            {
                _categorieId = value;
                OnPropertyChanged("CategorieId");
            }
        }
    }
}

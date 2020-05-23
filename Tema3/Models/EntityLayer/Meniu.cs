using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3.Models.EntityLayer
{
    public class Meniu : BasePropertyChanged
    {
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

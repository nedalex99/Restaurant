using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3.Models.EntityLayer
{
    public class CategoriiDePreparate : BasePropertyChanged
    {
        private int _categorieId;
        public int CategorieId 
        {
            get => _categorieId;
            set
            {
                _categorieId = value;
                OnPropertyChanged("CategorieId");
            }
        }

        private string _nume;
        public string Nume
        {
            get { return _nume; }
            set 
            {
                _nume = value;
                OnPropertyChanged("Nume");
            }
        }

    }
}

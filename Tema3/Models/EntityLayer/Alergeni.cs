using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3.Models.EntityLayer
{
    public class Alergeni : BasePropertyChanged
    {
        private int? _alergeniId;
        public int? AlergeniId
        {
            get { return _alergeniId; }
            set
            {
                _alergeniId = value;
                OnPropertyChanged("AlergeniId");
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
    }
}

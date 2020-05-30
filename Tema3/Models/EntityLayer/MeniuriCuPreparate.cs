using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3.Models.EntityLayer
{
    public class MeniuriCuPreparate : BasePropertyChanged
    {
        private string _denumireMeniu;
        public string DenumireMeniu
        {
            get { return _denumireMeniu; }
            set
            {
                _denumireMeniu = value;
                OnPropertyChanged("DenumireMeniu");
            }
        }

        private string _denumirePreparat;
        public string DenumirePreparat
        {
            get { return _denumirePreparat; }
            set
            {
                _denumirePreparat = value;
                OnPropertyChanged("DenumirePreparat");
            }
        }

        private int _cantitate;
        public int Cantitate
        {
            get { return _cantitate; }
            set
            {
                _cantitate = value;
                OnPropertyChanged("Cantitate");
            }
        }
    }
}

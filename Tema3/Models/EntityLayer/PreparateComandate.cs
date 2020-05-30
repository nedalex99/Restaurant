using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3.Models.EntityLayer
{
    public class PreparateComandate : BasePropertyChanged
    {
        private int? _comandaId;
        public int? ComandaId
        {
            get { return _comandaId; }
            set
            {
                _comandaId = value;
                OnPropertyChanged("ComandaId");
            }
        }

        private string _denumirePreparatDinComanda;
        public string DenumirePreparatDinComanda
        {
            get { return _denumirePreparatDinComanda; }
            set
            {
                _denumirePreparatDinComanda = value;
                OnPropertyChanged("DenumirePreparatDinComanda");
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

    }
}

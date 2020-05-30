using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3.Models.EntityLayer
{
    public class Comenzi : BasePropertyChanged
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


        private int? _clientId;
        public int? ClientId
        {
            get { return _clientId; }
            set
            {
                _clientId = value;
                OnPropertyChanged("ClientId");
            }
        }

    }
}

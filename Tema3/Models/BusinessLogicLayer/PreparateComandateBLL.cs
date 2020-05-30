using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.Models.DataAccesLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.Models.BusinessLogicLayer
{
    class PreparateComandateBLL
    {
        public ObservableCollection<PreparateComandate> PreparateComandate
        {
            get; set;
        }

        PreparateComandateDAL preparateComandateDAL = new PreparateComandateDAL();

        internal ObservableCollection<PreparateComandate> GetAllPreparateComandate()
        {
            return preparateComandateDAL.GetPreparateComandate();
        }

        internal void AddPreparatComandate(Comenzi comanda, Preparate preparat, int cantitate)
        {
            preparateComandateDAL.AddPreparatComandat(comanda, preparat, cantitate);
            //UserList.Add(user);
        }

        internal void DeletePreparatComandat(PreparateComandate preparatComandat)
        {
            preparateComandateDAL.DeletePreparatComandat(preparatComandat);
        }
    }
}

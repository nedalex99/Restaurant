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
    class ComenziBLL
    {
        public ObservableCollection<Comenzi> ComenziList
        {
            get; set;
        }

        ComenziDAL comenziDAL = new ComenziDAL();

        internal ObservableCollection<Comenzi> GetAllComenzi()
        {
            return comenziDAL.GetComenzi();
        }

        internal void AddComanda(Comenzi comanda)
        {
            comenziDAL.AddComenzi(comanda);
            //UserList.Add(user);
        }

        internal Comenzi GetComandaIdForClientId(Client client)
        {
            return comenziDAL.GetComandaIdForCliendId(client);
        }

        //internal void DeleteComanda(Comenzi comanda)
        //{
        //    comenziDAL.DeleteComanda(comanda);
        //}
    }
}

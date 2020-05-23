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
    class ClientBLL
    {
        public ObservableCollection<Client> ClientList { get; set; }

        ClientDAL clientDAL = new ClientDAL();

        internal ObservableCollection<Client> GetAllClients()
        {
            return clientDAL.GetClients();
        }

        internal void AddClient(Client user)
        {
            if (String.IsNullOrEmpty(user.Nume))
            {
                return;
            }
            clientDAL.AddClient(user);
            //UserList.Add(user);
        }

        internal bool GetClientWithEmailAndPassword(string email, string password)
        {
            var result = clientDAL.GetClientWithEmailAndPassword (email, password);
            if(result.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

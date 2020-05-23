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
    class MeniuBLL
    {
        public ObservableCollection<Meniu> Meniuri
        {
            get; set;
        }

        MeniuDAL meniuDAL = new MeniuDAL();

        internal ObservableCollection<Meniu> GetAllMeniu()
        {
            return meniuDAL.GetMeniu();
        }

        internal void AddMeniu(Meniu meniu)
        {
            if (String.IsNullOrEmpty(meniu.Denumire))
            {
                return;
            }
            meniuDAL.AddMeniu(meniu);
            //UserList.Add(user);
        }

        internal void DeleteMeniu(Meniu meniu)
        {
            meniuDAL.DeleteMeniu(meniu);
        }
    }
}

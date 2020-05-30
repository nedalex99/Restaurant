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
    class MeniuriCuPreparateBLL
    {
        public ObservableCollection<MeniuriCuPreparate> MeniuriCuPreparate
        {
            get; set;
        }

        MeniuriCuPreparatDAL meniuriCuPreparateDAL = new MeniuriCuPreparatDAL();

        internal ObservableCollection<MeniuriCuPreparate> GetAllMeniuriCuPreparate(Meniu meniu)
        {
            return meniuriCuPreparateDAL.GetMeniuriCuPreparate(meniu);
        }

        internal void AddMeniuCuPreparate(MeniuriCuPreparate meniuCuPreparate)
        {
            if (String.IsNullOrEmpty(meniuCuPreparate.DenumirePreparat))
            {
                return;
            }
            //meniuriCuPreparateDAL.AddMeniuCuPreparate(meniuCuPreparate);
            //UserList.Add(user);
        }

        internal void DeleteMeniuCuPreparate(MeniuriCuPreparate meniuCuPreparate)
        {
            //meniuriCuPreparateDAL.DeleteMeniuCuPreparate(meniuCuPreparate);
        }
    }
}

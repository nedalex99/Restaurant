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
    class PreparateBLL
    {
        public ObservableCollection<Preparate> Preparate
        {
            get; set;
        }

        PreparateDAL preparateDAL = new PreparateDAL();

        internal ObservableCollection<Preparate> GetAllPreparate()
        {
            return preparateDAL.GetPreparate();
        }

        internal void AddPreparat(Preparate preparat)
        {
            if (String.IsNullOrEmpty(preparat.Denumire))
            {
                return;
            }
            preparateDAL.AddPreparat(preparat);
            //UserList.Add(user);
        }

        internal void DeletePreparat(Preparate preparat)
        {
            preparateDAL.DeletePreparat(preparat);
        }
    }
}

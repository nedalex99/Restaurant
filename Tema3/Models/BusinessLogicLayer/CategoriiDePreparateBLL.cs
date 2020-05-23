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
    class CategoriiDePreparateBLL
    {
        public ObservableCollection<CategoriiDePreparate> CategoriiDePreparateList
        {
            get;set;
        }

        CategoriiDePreparateDAL categoriiDePreparateDAL = new CategoriiDePreparateDAL();

        internal ObservableCollection<CategoriiDePreparate> GetAllCategorii()
        {
            return categoriiDePreparateDAL.GetCategorii();
        }

        internal void AddCategorie(CategoriiDePreparate categorie)
        {
            if (String.IsNullOrEmpty(categorie.Nume))
            {
                return;
            }
            categoriiDePreparateDAL.AddCategorie(categorie);
            //UserList.Add(user);
        }

        internal void DeleteCategorie(CategoriiDePreparate categorie)
        {
            categoriiDePreparateDAL.DeleteCategorie(categorie);
        }
    }
}

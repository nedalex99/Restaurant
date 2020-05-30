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
    class AlergeniBLL
    {
        public ObservableCollection<Alergeni> AlergeniList
        {
            get; set;
        }

        AlergeniDAL alergeniDAL = new AlergeniDAL();

        internal ObservableCollection<Alergeni> GetAllAlergeni()
        {
            return alergeniDAL.GetAlergeni();
        }

        internal void AddAlergeni(Alergeni alergen)
        {
            if (String.IsNullOrEmpty(alergen.Denumire))
            {
                return;
            }
            alergeniDAL.AddAlergeni(alergen);
            //UserList.Add(user);
        }

        internal void DeleteAlergeni(Alergeni alergen)
        {
            alergeniDAL.DeleteAlergeni(alergen);
        }
    }
}

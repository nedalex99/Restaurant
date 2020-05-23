using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.Models.EntityLayer;

namespace Tema3.Models.DataAccesLayer
{
    public class MeniuDAL
    {
        public ObservableCollection<Meniu> GetMeniu()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spMeniuri_GetAll", connection);
                ObservableCollection<Meniu> result = new ObservableCollection<Meniu>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Meniu()
                        {
                            Denumire = reader["denumire"].ToString(),
                            Pret = reader["pret"] as decimal?,
                            CategorieId = reader["categorieId"] as int?
                        });
                }
                reader.Close();
                return result;
            }
        }

        internal void AddMeniu(Meniu meniu)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spMeniuri_Insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramDenumire = new SqlParameter("@Denumire", meniu.Denumire);
                SqlParameter paramPret = new SqlParameter("@Pret", meniu.Pret);
                SqlParameter paramCategorieId = new SqlParameter("CategorieId", meniu.CategorieId);

                cmd.Parameters.Add(paramDenumire);
                cmd.Parameters.Add(paramPret);
                cmd.Parameters.Add(paramCategorieId);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal void DeleteMeniu(Meniu meniu)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spMeniuri_Delete", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramDenumire = new SqlParameter("@Denumire", meniu.Denumire);
                cmd.Parameters.Add(paramDenumire);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

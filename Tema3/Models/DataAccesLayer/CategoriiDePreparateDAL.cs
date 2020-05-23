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
    public class CategoriiDePreparateDAL
    {
        public ObservableCollection<CategoriiDePreparate> GetCategorii()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spCategoriiDePreparate_GetAll", connection);
                ObservableCollection<CategoriiDePreparate> result = new ObservableCollection<CategoriiDePreparate>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new CategoriiDePreparate()
                        {
                            Nume = reader["nume"].ToString(),
                        });
                }
                reader.Close();
                return result;
            }
        }

        internal void AddCategorie(CategoriiDePreparate categorie)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spCategoriiDePreparate_Insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@Nume", categorie.Nume);

                cmd.Parameters.Add(paramNume);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal void DeleteCategorie(CategoriiDePreparate categorie)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spCategoriiDePreparate_Delete", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@Nume", categorie.Nume);
                cmd.Parameters.Add(paramNume);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

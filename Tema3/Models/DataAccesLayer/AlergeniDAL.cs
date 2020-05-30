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
    public class AlergeniDAL
    {
        public ObservableCollection<Alergeni> GetAlergeni()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spAlergeni_GetAll", connection);
                ObservableCollection<Alergeni> result = new ObservableCollection<Alergeni>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Alergeni()
                        {
                            AlergeniId = reader["alergeniId"] as int?,
                            Denumire = reader["denumire"].ToString()
                        });
                }
                reader.Close();
                return result;
            }
        }

        internal void AddAlergeni(Alergeni alergen)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spAlergeni_Insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramDenumire = new SqlParameter("@Denumire", alergen.Denumire);

                cmd.Parameters.Add(paramDenumire);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal void DeleteAlergeni(Alergeni alergeni)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spAlergeni_Delete", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramDenumire = new SqlParameter("@Denumire", alergeni.Denumire);
                cmd.Parameters.Add(paramDenumire);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

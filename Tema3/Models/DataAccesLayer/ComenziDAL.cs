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
    public class ComenziDAL
    {
        public ObservableCollection<Comenzi> GetComenzi()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spComenzi_GetAll", connection);
                ObservableCollection<Comenzi> result = new ObservableCollection<Comenzi>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Comenzi()
                        {
                            ComandaId = reader["comandaId"] as int?,
                            ClientId = reader["clientId"] as int?
                        });
                }
                reader.Close();
                return result;
            }
        }

        internal void AddComenzi(Comenzi comanda)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spComenzi_Insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramClientId = new SqlParameter("@ClientId", comanda.ClientId);

                cmd.Parameters.Add(paramClientId);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal Comenzi GetComandaIdForCliendId(Client client)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spComenzi_GetComandaIdForClientId", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramClientId = new SqlParameter("@ClientId", client.Id);
                cmd.Parameters.Add(paramClientId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Comenzi comanda = null;
                while (reader.Read())
                {
                    comanda = new Comenzi()
                    {
                        ComandaId = reader["comandaId"] as int?
                    };
                }
                return comanda;
            }
        }

        //internal void DeleteAlergeni(Alergeni alergeni)
        //{
        //    using (SqlConnection connection = DALHelper.Connection)
        //    {
        //        SqlCommand cmd = new SqlCommand("spAlergeni_Delete", connection);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        SqlParameter paramDenumire = new SqlParameter("@Denumire", alergeni.Denumire);
        //        cmd.Parameters.Add(paramDenumire);
        //        connection.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}
    }
}

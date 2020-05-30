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
    public class PreparateComandateDAL
    {
        public ObservableCollection<PreparateComandate> GetPreparateComandate()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spPreparateComandate_GetDenumirePreparate", connection);
                ObservableCollection<PreparateComandate> result = new ObservableCollection<PreparateComandate>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramComandaId = new SqlParameter("ComandaId", 3);
                cmd.Parameters.Add(paramComandaId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new PreparateComandate()
                        {
                            DenumirePreparatDinComanda = reader["denumire"].ToString(),
                        });
                }
                reader.Close();
                return result;
            }
        }

        internal void AddPreparatComandat(Comenzi comanda, Preparate preparat, int cantitate)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spPreparateComandate_Insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramComandaId = new SqlParameter("ComandaId", comanda.ComandaId);
                SqlParameter paramPreparatId = new SqlParameter("PreparatId", preparat.Id);
                SqlParameter paramCantitate = new SqlParameter("Cantitate", cantitate);

                cmd.Parameters.Add(paramComandaId);
                cmd.Parameters.Add(paramPreparatId);
                cmd.Parameters.Add(paramCantitate);

                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        internal void DeletePreparatComandat(PreparateComandate preparatComandat)
        {
            //using (SqlConnection connection = DALHelper.Connection)
            //{
            //    SqlCommand cmd = new SqlCommand("spPreparateComandate_Delete", connection);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    SqlParameter paramDenumire = new SqlParameter("@Denumire", preparatComandat.Denumire);
            //    cmd.Parameters.Add(paramDenumire);
            //    connection.Open();
            //    cmd.ExecuteNonQuery();
            //}
        }
    }
}

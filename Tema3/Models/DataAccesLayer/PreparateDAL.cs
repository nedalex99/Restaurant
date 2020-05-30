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
    public class PreparateDAL
    {
        public ObservableCollection<Preparate> GetPreparate()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spPreparate_GetAll", connection);
                ObservableCollection<Preparate> result = new ObservableCollection<Preparate>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Preparate()
                        {
                            Id = reader["preparatId"] as int?,
                            Denumire = reader["denumire"].ToString(),
                            Pret = reader["pret"] as decimal?,
                            Cantitate = reader["cantitate"] as int?,
                            CantitateTotala = reader["cantitateTotala"] as int?,
                            CategorieId = reader["categorieId"] as int?
                        });
                }
                reader.Close();
                return result;
            }
        }

        internal ObservableCollection<Preparate> GetPreparateForAlergen(Alergeni alergen)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spPreparateCuAlergeni_GetDenumirePreparat", connection);
                ObservableCollection<Preparate> result = new ObservableCollection<Preparate>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramDenumire = new SqlParameter("@Denumire", alergen.Denumire);
                cmd.Parameters.Add(paramDenumire);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Preparate()
                        {
                            Denumire = reader["denumire"].ToString()
                        });
                }
                reader.Close();
                return result;
            }
        }

        internal ObservableCollection<Preparate> GetPreparateForMeniu(Meniu meniu)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spMeniuriCuPreparate_GetDenumirePreparatForMeniu", connection);
                ObservableCollection<Preparate> result = new ObservableCollection<Preparate>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramDenumire = new SqlParameter("@Denumire", meniu.Denumire);
                cmd.Parameters.Add(paramDenumire);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Preparate()
                        {
                            Denumire = reader["denumire"].ToString()
                        });
                }
                reader.Close();
                return result;
            }
        }

        internal void AddPreparat(Preparate preparat)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spPreparate_Insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramDenumire = new SqlParameter("@Denumire", preparat.Denumire);
                SqlParameter paramPret = new SqlParameter("@Pret", preparat.Pret);
                SqlParameter paramCantitate = new SqlParameter("Cantitate", preparat.Cantitate);
                SqlParameter paramCantitateTotala = new SqlParameter("CantitateTotala", preparat.CantitateTotala);
                SqlParameter paramCategorieId = new SqlParameter("CategorieId", preparat.CategorieId);

                cmd.Parameters.Add(paramDenumire);
                cmd.Parameters.Add(paramPret);
                cmd.Parameters.Add(paramCantitate);
                cmd.Parameters.Add(paramCantitateTotala);
                cmd.Parameters.Add(paramCategorieId);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        internal void DeletePreparat(Preparate preparat)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spPreparate_Delete", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramDenumire = new SqlParameter("@Denumire", preparat.Denumire);
                cmd.Parameters.Add(paramDenumire);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

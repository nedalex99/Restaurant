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
    public class MeniuriCuPreparatDAL
    {
        public ObservableCollection<MeniuriCuPreparate> GetMeniuriCuPreparate(Meniu meniu)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spMeniuriCuPreparate_GetPreparatFromMeniu", connection);
                ObservableCollection<MeniuriCuPreparate> result = new ObservableCollection<MeniuriCuPreparate>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramDenumireMeniu = new SqlParameter("@DenumireMeniu", meniu.Denumire);

                cmd.Parameters.Add(paramDenumireMeniu);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new MeniuriCuPreparate()
                    {
                        DenumirePreparat = reader["denumire"].ToString()
                    });

                }
                reader.Close();
                return result;
            }
        }

        //internal void AddMeniu(Meniu meniu)
        //{
        //    using (SqlConnection connection = DALHelper.Connection)
        //    {
        //        SqlCommand cmd = new SqlCommand("spMeniuri_Insert", connection);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        SqlParameter paramDenumire = new SqlParameter("@Denumire", meniu.Denumire);
        //        SqlParameter paramPret = new SqlParameter("@Pret", meniu.Pret);
        //        SqlParameter paramCategorieId = new SqlParameter("CategorieId", meniu.CategorieId);

        //        cmd.Parameters.Add(paramDenumire);
        //        cmd.Parameters.Add(paramPret);
        //        cmd.Parameters.Add(paramCategorieId);

        //        connection.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        //internal void DeleteMeniu(Meniu meniu)
        //{
        //    using (SqlConnection connection = DALHelper.Connection)
        //    {
        //        SqlCommand cmd = new SqlCommand("spMeniuri_Delete", connection);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        SqlParameter paramDenumire = new SqlParameter("@Denumire", meniu.Denumire);
        //        cmd.Parameters.Add(paramDenumire);
        //        connection.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}
    }
}

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
    public class ClientDAL
    {
        public ObservableCollection<Client> GetClients()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spClient_GetAll", connection);
                ObservableCollection<Client> result = new ObservableCollection<Client>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Client()
                        {
                            Nume = reader["nume"].ToString(),
                            Prenume = reader["prenume"].ToString(),
                            Email = reader["email"].ToString(),
                            Telefon = reader["telefon"].ToString(),
                            Adresa = reader["adresa"].ToString(),
                            Password = reader["parola"].ToString()
                        });
                }
                reader.Close();
                return result;
            }
        }

        internal void AddClient(Client user)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spClient_Insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@Nume", user.Nume);
                SqlParameter paramPrenume = new SqlParameter("@Prenume", user.Prenume);
                SqlParameter paramEmail = new SqlParameter("@Email", user.Email);
                SqlParameter paramTelefon = new SqlParameter("@Telefon", user.Telefon);
                SqlParameter paramAdresa = new SqlParameter("@Adresa", user.Adresa);
                SqlParameter paramParola = new SqlParameter("@Parola", user.Password);

                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramPrenume);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramTelefon);
                cmd.Parameters.Add(paramAdresa);
                cmd.Parameters.Add(paramParola);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal ObservableCollection<Client> GetClientWithEmailAndPassword(string email, string parola)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spClients_GetClientWithEmailAndPassword", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramEmail = new SqlParameter("@Email", email);
                SqlParameter paramParola = new SqlParameter("@Parola", parola);

                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramParola);

                ObservableCollection<Client> result = new ObservableCollection<Client>();

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Client()
                        {
                            Id = reader["clientId"] as int?,
                            Nume = reader["nume"].ToString(),
                            Prenume = reader["prenume"].ToString(),
                            Email = reader["email"].ToString(),
                            Telefon = reader["telefon"].ToString(),
                            Adresa = reader["adresa"].ToString(),
                            Password = reader["parola"].ToString()
                        });
                }

                reader.Close();

                return result;
            }
        }
    }
}

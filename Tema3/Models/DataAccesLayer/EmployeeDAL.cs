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
    public class EmployeeDAL
    {
        public ObservableCollection<Employee> GetEmployees()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spAngajati_GetAll", connection);
                ObservableCollection<Employee> result = new ObservableCollection<Employee>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Employee()
                        {
                            Nume = reader["nume"].ToString(),
                            Prenume = reader["prenume"].ToString(),
                            Email = reader["email"].ToString(),
                            Telefon = reader["telefon"].ToString(),
                            Password = reader["parola"].ToString()
                        });
                }
                reader.Close();
                return result;
            }
        }

        internal void AddEmployee(Employee employee)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spAngajati_Insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@Nume", employee.Nume);
                SqlParameter paramPrenume = new SqlParameter("@Prenume", employee.Prenume);
                SqlParameter paramEmail = new SqlParameter("@Email", employee.Email);
                SqlParameter paramTelefon = new SqlParameter("@Telefon", employee.Telefon);
                SqlParameter paramParola = new SqlParameter("@Parola", employee.Password);

                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramPrenume);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramTelefon);
                cmd.Parameters.Add(paramParola);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal ObservableCollection<Employee> GetEmployeeWithEmailAndPassword(string email, string parola)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("spAngajati_GetAngajatWithEmailAndPassword", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramEmail = new SqlParameter("@Email", email);
                SqlParameter paramParola = new SqlParameter("@Parola", parola);

                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramParola);

                ObservableCollection<Employee> result = new ObservableCollection<Employee>();

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Employee()
                        {
                            Id = reader["angajatId"] as int?,
                            Nume = reader["nume"].ToString(),
                            Prenume = reader["prenume"].ToString(),
                            Email = reader["email"].ToString(),
                            Telefon = reader["telefon"].ToString(),
                            Password = reader["parola"].ToString()
                        });
                }

                reader.Close();

                return result;
            }
        }
    }
}

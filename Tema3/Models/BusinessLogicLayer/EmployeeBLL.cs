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
    class EmployeeBLL
    {
        public ObservableCollection<Employee> EmployeeList { get; set; }

        EmployeeDAL employeeDAL = new EmployeeDAL();

        internal ObservableCollection<Employee> GetAllEmployees()
        {
            return employeeDAL.GetEmployees();
        }

        internal void AddEmployee(Employee employee)
        {
            if (String.IsNullOrEmpty(employee.Nume))
            {
                return;
            }
            employeeDAL.AddEmployee(employee);
            //UserList.Add(user);
        }

        internal bool GetEmployeeWithEmailAndPassword(string email, string password)
        {
            var result = employeeDAL.GetEmployeeWithEmailAndPassword(email, password);
            if (result.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using Dapper;
using DemoAPI.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.DataAccess
{
    public class DAEmployee : DABase
    {
        private List<Employee> _employees;
        private string _connectionString;

        public DAEmployee(string connectionString)
        {
            _connectionString = connectionString;
            _employees = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            string sqlInsertEmployee = GetSqlInsert(employee);

            using (var connection = new SqlConnection(_connectionString))
            {
                employee.CreateDateTime = DateTime.Now;
                employee.ModifyDateTime = DateTime.Now;
                var affectedRows = connection.Execute(
                    sqlInsertEmployee,
                    new
                    {
                        employee.FirstName,
                        employee.LastName,
                        employee.Age,
                        employee.Salary,
                        employee.CreateBy,
                        employee.CreateDateTime,
                        employee.ModifyBy,
                        employee.ModifyDateTime
                    });
                Console.WriteLine(affectedRows);
            }

            if (employee != null)
            {
                _employees.Add(employee);
            }
        }

        public Employee GetById(int id)
        {
            string sqlEmployee = "SELECT * FROM Employee WHERE Id = @employee_id";
            using (var connection = new SqlConnection(_connectionString))
            {
                _employees = connection.Query<Employee>(sqlEmployee, new { employee_id = id }).ToList();
            }
            if (_employees.Count > 0)
            {
                return _employees.Where(x => x.Id == id).FirstOrDefault();
            }
            return new Employee();
        }

        public IEnumerable<Employee> GetAll()
        {
            string sqlEmployees = "SELECT * FROM Employee";
            using (var connection = new SqlConnection(_connectionString))
            {
                _employees = connection.Query<Employee>(sqlEmployees).ToList();
            }
            return _employees;
        }
        
    }
}

using DemoAPI.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.DataAccess
{
    public class DAEmployee
    {
        private List<Employee> _employees;
        private Employee _employee;

        public DAEmployee()
        {
            _employees = new List<Employee>();
            //_employee = new Employee()
            //{
            //    Id = 1,
            //    FirstName = "Sumet",
            //    LastName = "Funan",
            //    Age = 25
            //};
            //_employees.Add(_employee);
        }

        public void Add(Employee employee)
        {
            if (employee != null)
            {
                _employees.Add(employee);
            }
        }

        public Employee GetById(int id)
        {
            if (_employees.Count > 0)
            {
                return _employees.Where(x => x.Id == id).FirstOrDefault();
            }
            return new Employee();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }
        
    }
}

using DemoAPI.DataAccess;
using DemoAPI.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Business
{
    public class EmployeeLogic
    {
        private DAEmployee _daEmployee;

        public EmployeeLogic()
        {
            _daEmployee = new DAEmployee();
        }

        public void Add(Employee employee)
        {
            _daEmployee.Add(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _daEmployee.GetAll();
        }

        public Employee GetById(int id)
        {
            return _daEmployee.GetById(id);
        }
    }
}

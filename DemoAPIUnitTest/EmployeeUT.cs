using System;
using System.Configuration;
using System.Linq;
using DemoAPI.Business;
using DemoAPI.DataAccess;
using DemoAPI.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoAPIUnitTest
{
    [TestClass]
    public class EmployeeUT
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        [TestMethod]
        public void AddSingleEmp()
        {
            // arrange
            int id = 11;
            string firstName = "Sumet";
            string lastName = "Funan";
            int age = 25;

            Employee employee = new Employee()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };

            // act
            EmployeeLogic daEmployee = new EmployeeLogic(_connectionString);
            daEmployee.Add(employee);

            // assert
            var result = daEmployee.GetById(id);

            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(firstName, result.FirstName);
            Assert.AreEqual(lastName, result.LastName);
            Assert.AreEqual(age, result.Age);
        }

        [TestMethod]
        public void AddTwoEmp()
        {
            // arrange
            Employee employee1 = SetEmployee(12, "Sumet", "Funan", 25, 5, 1, DateTime.Now, 1, DateTime.Now);
            Employee employee2 = SetEmployee(13, "Hello", "World", 28, 8, 1, DateTime.Now, 1, DateTime.Now);

            // act
            EmployeeLogic employeeLogic = new EmployeeLogic(_connectionString);
            employeeLogic.Add(employee1);
            employeeLogic.Add(employee2);

            // assert
            var result1 = employeeLogic.GetById(employee1.Id);
            var result2 = employeeLogic.GetById(employee2.Id);

            AssertEmployee(employee1.Id, employee1.FirstName, employee1.LastName, employee1.Age, result1);
            AssertEmployee(employee2.Id, employee2.FirstName, employee2.LastName, employee2.Age, result2);
        }

        private static void AssertEmployee(int id, string firstName, string lastName, int age, Employee result)
        {
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(firstName, result.FirstName);
            Assert.AreEqual(lastName, result.LastName);
            Assert.AreEqual(age, result.Age);
        }

        private static Employee SetEmployee(int id, string firstName, string lastName, int age, decimal salary, Int64 create_by, DateTime create_datetime, Int64 modify_by, DateTime modify_datetime)
        {
            return new Employee()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Salary = salary,
                CreateBy = create_by,
                CreateDateTime = create_datetime,
                ModifyBy = modify_by,
                ModifyDateTime = modify_datetime
            };
        }
    }
}

using System;
using System.Linq;
using DemoAPI.DataAccess;
using DemoAPI.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoAPIUnitTest
{
    [TestClass]
    public class EmployeeUT
    {
        [TestMethod]
        public void AddSingleEmp()
        {
            // arrange
            int id = 1;
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
            DAEmployee daEmployee = new DAEmployee();
            daEmployee.Add(employee);

            // assert
            var result = daEmployee.GetAll().ToList()[0];

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Sumet", result.FirstName);
            Assert.AreEqual("Funan", result.LastName);
            Assert.AreEqual(25, result.Age);
        }

        [TestMethod]
        public void AddTwoEmp()
        {
            // arrange
            Employee employee1 = SetEmployee(1, "Sumet", "Funan", 25);
            Employee employee2 = SetEmployee(2, "Hello", "World", 28);

            // act
            DAEmployee daEmployee = new DAEmployee();
            daEmployee.Add(employee1);
            daEmployee.Add(employee2);

            // assert
            var result = daEmployee.GetAll().ToList();

            Assert.AreEqual(2, result.Count);

            AssertEmployee(1, "Sumet", "Funan", 25, result[0]);
            AssertEmployee(2, "Hello", "World", 28, result[1]);
        }

        private static void AssertEmployee(int id, string firstName, string lastName, int age, Employee result)
        {
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(firstName, result.FirstName);
            Assert.AreEqual(lastName, result.LastName);
            Assert.AreEqual(age, result.Age);
        }

        private static Employee SetEmployee(int id, string firstName, string lastName, int age)
        {
            return new Employee()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Objects
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public decimal Salary { get; set; }

        public bool IsUsed { get; set; }

        public Int64 CreateBy { get; set; }

        public DateTime CreateDateTime { get; set; }

        public Int64 ModifyBy { get; set; }

        public DateTime ModifyDateTime { get; set; }
    }
}

using DemoAPI.Business;
using DemoAPI.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public EmployeeLogic _employeeLogic = new EmployeeLogic();

        [HttpPost]
        public IHttpActionResult Add([FromBody]Employee employee)
        {
            _employeeLogic.Add(employee);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_employeeLogic.GetAll());
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_employeeLogic.GetById(id));
        }
    }
}

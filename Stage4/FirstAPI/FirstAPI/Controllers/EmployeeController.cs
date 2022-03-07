using FirstAPI.Models;
using FirstAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepo<int, Employee> _repo;

        public EmployeeController(IRepo<int,Employee> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public ActionResult<ICollection<Employee>> G3()
        {
            return Ok(_repo.GetAll());
        }
        [Route("GetEmployeeByID")]
        [HttpGet]
        public ActionResult<ICollection<Employee>> G3(int id)
        {
            return Ok(_repo.Get(id));
        }
        [HttpPost]
        public ActionResult<Employee> Post(Employee employee)
        {
            var _employee = _repo.Add(employee);
            return Created("Added", _employee);
        }
        [HttpPut]
        public ActionResult<Employee> Put(int id,Employee employee)
        {
            var _employee = _repo.Update(employee);
            return Ok(_employee);
        }
        [HttpDelete]
        public ActionResult<Employee> Delete(int id)
        {
            var _employee = _repo.Delete(id);
            return _employee;
        }
    }
}

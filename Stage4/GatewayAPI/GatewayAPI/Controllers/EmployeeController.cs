using GatewayAPI.Models;
using GatewayAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("allow")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepo<int, Employee> _repo;

        public EmployeeController(IRepo<int, Employee> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<Employee>>> G3()
        {
            return Ok(await _repo.GetAll());
        }
        [Route("GetEmployeeByID")]
        [HttpGet]
        public async Task<ActionResult<ICollection<Employee>>> G3(int id)
        {
            return Ok(await _repo.Get(id));
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            var _employee = await _repo.Add(employee);
            return Created("Added", _employee);
        }
        [HttpPut]
        public async Task<ActionResult<Employee>> Put(int id, Employee employee)
        {
            var _employee = await _repo.Update(employee);
            return Ok(_employee);
        }
        [HttpDelete]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var _employee = await _repo.Delete(id);
            return Ok(_employee);
        }
    }
}

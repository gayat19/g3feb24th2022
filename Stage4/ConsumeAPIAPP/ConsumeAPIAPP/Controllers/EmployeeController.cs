using ConsumeAPIAPP.Models;
using ConsumeAPIAPP.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeAPIAPP.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepo<int, Employee> _repo;

        public EmployeeController(IRepo<int,Employee> repo)
        {
            _repo = repo;
        }

        public async Task<ActionResult> Index()
        {
            var employees = await _repo.GetAll();
            return View(employees);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Employee employee)
        {
            var emp = await _repo.Add(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var emp = await _repo.Get(id);
            return View(emp);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id,Employee employee)
        {
            var emp = await _repo.Update(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var emp = await _repo.Get(id);
            return View(emp);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Employee employee)
        {
            var emp = await _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

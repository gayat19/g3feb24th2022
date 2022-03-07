using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Services
{
    public class EmployeeRepoEF : IRepo<int, Employee>
    {
        private readonly CompanyContext _context;

        public EmployeeRepoEF(CompanyContext context)
        {
            _context = context;
        }
        public Employee Add(Employee item)
        {
            _context.Employees.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Employee Delete(int id)
        {
            var emp = Get(id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return emp;
        }

        public Employee Get(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);
            return employee;
        }

        public ICollection<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee Update(Employee item)
        {
            var emp = Get(item.Id);
            emp.Name = item.Name;
            emp.Age = item.Age;
            _context.SaveChanges();
            return emp;
        }
    }
}

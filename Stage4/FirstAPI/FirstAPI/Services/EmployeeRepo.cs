using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Services
{
    public class EmployeeRepo : IRepo<int, Employee>
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee{Id=101,Name="Ramu",Age=21},
            new Employee{Id=102,Name="Bimu",Age=23}
        };

        public Employee Add(Employee item)
        {
            employees.Add(item);
            return item;
        }

        public Employee Delete(int id)
        {
            var emp = employees.Find(e => e.Id == id);
            employees.RemoveAt(id-100-1);
            return emp;
        }

        public Employee Get(int id)
        {
            return employees.Find(e => e.Id == id);
        }

        public ICollection<Employee> GetAll()
        {
            return employees;
        }

        public Employee Update(Employee item)
        {
            var emp = employees.Find(e => e.Id == item.Id);
            if(emp !=null)
            {
                emp.Name = item.Name;
                emp.Age = item.Age;
            }
            return emp;
        }
    }
}

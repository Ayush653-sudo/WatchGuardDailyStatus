using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Models
{
    public class MockEmployeeRespository:IEmployeeRepository
    {
        List<Employee> _employee;
        public MockEmployeeRespository()
        {
            _employee = new List<Employee>()
            {
                new Employee(){Id=1,Name="Mary",Department="HR",Email="ayushsinght70@gmail.com" },
                new Employee(){Id=2,Name="Sammy",Department="HR",Email="singht70@gmail.com"}
            };
        }
        public  Employee GetEmployee(int id)
        {
            return _employee.FirstOrDefault(e => e.Id == id);
        }
    }
}

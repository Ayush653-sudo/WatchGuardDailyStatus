using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
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
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employee;
        }
        public Employee Add(Employee employee) 
        {
         employee.Id=_employee.Max(e=>e.Id)+1;
            _employee.Add(employee);
            return employee;
        }

        Employee IEmployeeRepository.Update(Employee employeeChange)
        {
            Employee employee = _employee.FirstOrDefault(e => e.Id == employeeChange.Id);
            if (employee != null)
            {
                employee.Name = employeeChange.Name;
                employee.Department = employeeChange.Department;
                employee.Email= employeeChange.Email;
            }
            return employee;
        }

       public Employee Delete(int id)
        {
         Employee employee= _employee.FirstOrDefault(e => e.Id == id);
            if(employee!=null)
                _employee.Remove(employee);
            return employee;

        }
    }
}

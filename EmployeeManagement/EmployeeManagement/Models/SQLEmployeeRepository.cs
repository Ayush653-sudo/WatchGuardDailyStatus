using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository:IEmployeeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<SQLEmployeeRepository> logger; 
        public SQLEmployeeRepository(AppDbContext context,
            ILogger<SQLEmployeeRepository>logger
            ) 
        { 
          this.context = context;
            this.logger = logger;
        }

       public Employee Add(Employee employee)
        {
           
            throw new System.NotImplementedException();

        }

       public Employee Delete(int id)
        {
            throw new System.NotImplementedException();
        }

       public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employees;
        }

       public Employee GetEmployee(int id)
        {

            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical log");
            return context.Employees.Find(id);
        }

      public  Employee Update(Employee employeeChange)
        {
            var employee = context.Employees.Attach(employeeChange);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChange;
        }
    }
}

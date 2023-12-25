using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                
                new Employee
                {
                                       
                    Id=1,
                    Name="Mark",
                    Email="ayush@gmail.com",
                    Department="IT"

                }
                
                
                );
        }

    }
}

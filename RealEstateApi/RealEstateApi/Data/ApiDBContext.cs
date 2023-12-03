using Microsoft.EntityFrameworkCore;
using RealEstateApi.Models;

namespace RealEstateApi.Data
{
    public class ApiDBContext:DbContext
    {
        public DbSet<Category>categories { get; set; }
        public DbSet<User>users { get; set; }
        public DbSet<Property> properties { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RealEstateDb");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class QuotesDbContext : DbContext
    {
        public QuotesDbContext(DbContextOptions<QuotesDbContext>options):base(options) 
        {
        
        }
        public DbSet<Quotes>Quotes{get;set;}


    }
}

using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class QuotesDbContext : DbContext
    {

        public DbSet<Quotes>Quotes{get;set;}


    }
}

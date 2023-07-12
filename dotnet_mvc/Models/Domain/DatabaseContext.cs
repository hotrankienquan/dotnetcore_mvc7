using Microsoft.EntityFrameworkCore;

namespace dotnet_mvc.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { 
               
        }
        public DbSet<Person> Person { get; set; }

    }
}

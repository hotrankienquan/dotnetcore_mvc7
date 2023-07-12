using Microsoft.EntityFrameworkCore;

namespace dotnet_mvc.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { 
               
        }
        public DbSet<Person> Person { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<Publisher> Publisher { get; set; } 

        public DbSet<Book> Book { get; set; }

    }
}

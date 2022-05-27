using Microsoft.EntityFrameworkCore;

namespace RestWithAspNET5Udemy.Model.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext()
        {

        }
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) { }
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}

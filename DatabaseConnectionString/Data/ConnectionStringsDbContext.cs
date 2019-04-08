using DatabaseConnectionString.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnectionString.Data
{
    public class ConnectionStringsDbContext : DbContext
    {
        public ConnectionStringsDbContext(DbContextOptions<ConnectionStringsDbContext> options) : base(options) { }
        
        public DbSet<ConnectionString> ConnectionStrings { get; set; }
    }
}

using IslandGarageAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IslandGarageAPI.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using WebApplication5.model;

namespace WebApplication5.Data
{
    public class LogisticsDbContext : DbContext
    {
        public LogisticsDbContext(DbContextOptions<LogisticsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
    }
}

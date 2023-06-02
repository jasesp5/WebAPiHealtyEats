
using Microsoft.EntityFrameworkCore;
using WebApiHealtyEats.Models;
using WebAPiHealtyEats.Models;

namespace WebApiHealtyEats.Data
{
 public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
            modelBuilder.Entity<HealthStatus>().HasData(
                new HealthStatus { Id = 1, Description = "Healthy" },
                new HealthStatus { Id = 2, Description = "Moderate" },
                new HealthStatus { Id = 3, Description = "Unhealthy" }
            );


        }

        public DbSet<User> User { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<HealthStatus> HealthStatuses { get; set; }
    }
}

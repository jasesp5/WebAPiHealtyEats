
using WebApiHealtyEats.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiHealtyEats.Data
{
 public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }


        
        public DbSet<User> User { get; set; }
    }
}

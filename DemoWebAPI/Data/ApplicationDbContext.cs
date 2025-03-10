using DemoWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}

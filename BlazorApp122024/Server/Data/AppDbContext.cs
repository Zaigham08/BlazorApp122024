
using Microsoft.EntityFrameworkCore;
using BlazorApp122024.Shared;

namespace BlazorApp122024.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Course> Students { get; set; }

    }
}

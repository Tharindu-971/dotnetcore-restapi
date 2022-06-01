using DXDY.REST.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DXDY.REST.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }
    }
}

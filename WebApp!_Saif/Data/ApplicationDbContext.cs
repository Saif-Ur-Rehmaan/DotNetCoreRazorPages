using System.Data;
using Microsoft.EntityFrameworkCore;
using WebApp__Saif.Model;
namespace WebApp__Saif.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {}
        public DbSet<Category> Category { get; set; }

    }
}

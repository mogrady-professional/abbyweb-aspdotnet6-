using AbbyWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace AbbyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // base is used to inherit the constructor of the parent class
        {
                
        }
        public DbSet<Category> Category { get; set; }

    }
}

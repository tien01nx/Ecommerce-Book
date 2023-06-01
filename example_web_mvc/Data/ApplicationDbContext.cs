using example_web_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace example_web_mvc.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }

    }
}

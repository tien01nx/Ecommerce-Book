using example_web_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace example_web_mvc.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Tien",
                    DisplayOrder = 2
                },
                new Category
                {
                    Id = 2,
                    Name = "Diu",
                    DisplayOrder = 9
                },
                new Category
                {
                    Id = 3,
                    Name = "Manh",
                    DisplayOrder = 5
                });
        }

    }
}

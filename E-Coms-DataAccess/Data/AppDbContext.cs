using E_Coms_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Coms_DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Cloths",
                    DisplayOrder = 1
                },
                new Category
                {
                    Id = 2,
                    Name = "Shoes",
                    DisplayOrder = 2
                },
                new Category
                {
                    Id = 3,
                    Name = "Bags",
                    DisplayOrder = 3
                });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
    }
}

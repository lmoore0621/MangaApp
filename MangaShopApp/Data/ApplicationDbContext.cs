using MangaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaWeb.Data
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
                new Category() { Id = 1, Name = "Shôjo", DisplayOrder = 01 },
                new Category() { Id = 2, Name = "Josei", DisplayOrder = 02 },
                new Category() { Id = 3, Name = "Shônen", DisplayOrder = 03 }
            );
        }
    }
}
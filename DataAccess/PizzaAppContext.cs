using Microsoft.EntityFrameworkCore;
using PizzaGoAPI.Entities;

namespace PizzaGoAPI.DBContext
{
    public class PizzaAppContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategorySize> CategorySizes { get; set; }

        public PizzaAppContext(DbContextOptions<PizzaAppContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    }
}

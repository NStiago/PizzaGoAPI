using Microsoft.EntityFrameworkCore;
using PizzaGoAPI.Entities;

namespace PizzaGoAPI.DBContext
{
    public class PizzaAppContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategorySize> CategorySizes { get; set; }
        public DbSet<AddedIngridient> AddedIngridients { get; set; }

        public PizzaAppContext(DbContextOptions<PizzaAppContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                 new { Id = 1, Name = "Пицца" },
                 new { Id = 2, Name = "Десерт" },
                 new { Id = 3, Name = "Напиток" }
                );
            modelBuilder.Entity<Product>().HasData(
                new { Id = 1, Name = "Пепперони", Price=200, Description="Some description of peperonni", CategoryId = 1},
                new { Id = 2, Name = "С ананасами", Price = 250, Description = "Some description of pizza with pineaple", CategoryId = 1},
                new { Id = 3, Name = "Карбонара", Price = 220, Description = "Some description of carbonara", CategoryId = 1},
                new { Id = 4, Name = "Шоколадный чизкейк", Price = 50, Description = "Very unusual cake", CategoryId = 2},
                new { Id = 5, Name = "Молочный коктейль", Price = 30, Description = "Some Cocktail", CategoryId = 3}
                );

            modelBuilder.Entity<CategorySize>().HasData(
                new { Id = 1, Name = "Маленькая", Capacity = 25.0, CategoryId = 1 },
                new { Id = 2, Name = "Средняя", Capacity = 30.0, CategoryId = 1 },
                new { Id = 3, Name = "Большая", Capacity = 35.0, CategoryId = 1 },
                new { Id = 4, Name = "Маленький", Capacity = 0.33, CategoryId = 3 },
                new { Id = 5, Name = "Средний", Capacity = 0.5, CategoryId = 3 },
                new { Id = 6, Name = "Большой", Capacity = 1.0, CategoryId = 3 }
                );

            modelBuilder.Entity<AddedIngridient>().HasData(
                new { Id = 1, Name = "Халапенью", Price = 59 },
                new { Id = 2, Name = "Сыр", Price = 29 },
                new { Id = 3, Name = "Кетчуп", Price = 19 }
                );
        }
    }
}

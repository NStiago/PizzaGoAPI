using PizzaGoAPI.Models;

namespace PizzaGoAPI
{
    public class ProductDataStore
    {
        public List<Product> Pizzas { get; set; }

        public static ProductDataStore Current { get; } = new ProductDataStore();
        public ProductDataStore()
        {
            Pizzas = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Pepperoni",
                    Price=200,
                    Description = "best pizza"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Pizza with Pineapple",
                    Price=100,
                    Description = "not good pizza"
                },
                new Product()
                {
                    Id = 3,
                    Name = "4 cheeses",
                    Price=400,
                    Description = "4 cheeses Masserati"
                }
            };
        }
    }
}

using PizzaGoAPI.Models;

namespace PizzaGoAPI
{
    public class CategoryDataStore
    {
        public List<Category> Categories { get; set; }

        public static CategoryDataStore Current { get; } = new CategoryDataStore();
        public CategoryDataStore()
        {
            Categories = new List<Category>()
            {
               new Category()
               {
                   Id=1,
                   Name = "Pizza",
                   Products = new List<Product>()
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
                   }
               },
               new Category()
               {
                   Id=2,
                   Name = "Dessert",
                   Products = new List<Product>()
                   {
                       new Product
                       {
                           Id=4,
                           Name = "Chocolate cake",
                           Price=250,
                       }
                   }
               },
               new Category()
               {
                   Id=3,
                   Name = "Drink",
                   Products = new List<Product>()
                   {
                       new Product
                       {
                           Id=5,
                           Name = "Coca cola",
                           Price=50,
                       }
                   }
               },
            };
        }
    }
}

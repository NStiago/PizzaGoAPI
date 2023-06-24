using PizzaGoAPI.Models;

namespace PizzaGoAPI
{
    public class CategoryDataStore
    {
        public List<CategoryDTO> Categories { get; set; }

        public static CategoryDataStore Current { get; } = new CategoryDataStore();
        public CategoryDataStore()
        {
            Categories = new List<CategoryDTO>()
            {
               new CategoryDTO()
               {
                   Id=1,
                   Name = "Pizza",
                   Products = new List<ProductDTO>()
                   {
                        new ProductDTO()
                        {
                            Id = 1,
                            Name = "Pepperoni",
                            Price=200,
                            Description = "best pizza"
                        },
                        new ProductDTO()
                        {
                            Id = 2,
                            Name = "Pizza with Pineapple",
                            Price=100,
                            Description = "not good pizza"
                        },
                        new ProductDTO()
                        {
                            Id = 3,
                            Name = "4 cheeses",
                            Price=400,
                            Description = "4 cheeses Masserati"
                        }
                   }
               },
               new CategoryDTO()
               {
                   Id=2,
                   Name = "Dessert",
                   Products = new List<ProductDTO>()
                   {
                       new ProductDTO
                       {
                           Id=4,
                           Name = "Chocolate cake",
                           Price=250,
                       }
                   }
               },
               new CategoryDTO()
               {
                   Id=3,
                   Name = "Drink",
                   Products = new List<ProductDTO>()
                   {
                       new ProductDTO
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

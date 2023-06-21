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
                   Name = "Pizza"
               },
               new Category()
               {
                   Id=2,
                   Name = "Dessert"
               },
               new Category()
               {
                   Id=3,
                   Name = "Drink"
               },
            };
        }
    }
}

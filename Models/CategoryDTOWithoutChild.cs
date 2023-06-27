using PizzaGoAPI.Entities;

namespace PizzaGoAPI.Models
{
    public class CategoryDTOWithoutChild
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public ICollection<Product> Products { get; set; }
        //public ICollection<CategorySize> CategorySizes { get; set; }

    }
}

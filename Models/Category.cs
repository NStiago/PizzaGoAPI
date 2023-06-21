namespace PizzaGoAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<CategorySize> CategorySizes { get; set; } = new List<CategorySize>();
    }
}

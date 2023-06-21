namespace PizzaGoAPI.Models
{
    public class Ingridient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

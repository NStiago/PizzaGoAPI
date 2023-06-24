namespace PizzaGoAPI.Models
{
    public class AddedIngridientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}

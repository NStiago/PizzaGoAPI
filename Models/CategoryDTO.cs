namespace PizzaGoAPI.Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public ICollection<CategorySizeDTO> CategorySizes { get; set; } = new List<CategorySizeDTO>();
    }
}

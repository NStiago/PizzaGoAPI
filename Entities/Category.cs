using PizzaGoAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaGoAPI.Entities
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } 
        public ICollection<CategorySize> CategorySizes { get; set; }
    }
}

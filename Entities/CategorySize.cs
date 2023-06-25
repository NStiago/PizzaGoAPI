using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaGoAPI.Entities
{
    public class CategorySize
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Capacity { get; set; }

        
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}

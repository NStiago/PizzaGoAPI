using PizzaGoAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaGoAPI.Entities
{
    public class AddedIngridient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        
    }
}

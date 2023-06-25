using PizzaGoAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaGoAPI.Entities
{
    public class AddedIngridient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        
    }
}

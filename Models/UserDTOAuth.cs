using System.ComponentModel.DataAnnotations;

namespace PizzaGoAPI.Models
{
    public class UserDTOAuth
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

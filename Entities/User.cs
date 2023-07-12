using System.ComponentModel.DataAnnotations;

namespace PizzaGoAPI.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength (100)]
        public string Surname { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }

    }
}

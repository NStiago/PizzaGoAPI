﻿using System.ComponentModel.DataAnnotations;

namespace PizzaGoAPI.Models
{
    public class UserAuth
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

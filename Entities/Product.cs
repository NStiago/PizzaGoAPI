﻿using PizzaGoAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaGoAPI.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}

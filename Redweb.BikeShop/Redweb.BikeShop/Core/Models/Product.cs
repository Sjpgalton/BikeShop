using System;
using System.ComponentModel.DataAnnotations;

namespace Redweb.BikeShop.Core.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Subcategory Subcategory { get; set; }

        [Required]
        public Model Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Colour Colour { get; set; }

        public Size Size { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
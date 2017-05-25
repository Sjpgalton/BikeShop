using Redweb.BikeShop.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Redweb.BikeShop.Core.ViewModels
{
    public class AddProductViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public string ProductCode { get; set; }
        
        [Required]
        public string ProductName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SubcategoryId { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int ColourId { get; set; }

        public int SizeId { get; set; }

        [Required]
        public string Description { get; set; }


        // To store all the values form the database
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Subcategory> Subcategories { get; set; }
        public IEnumerable<Model> Models { get; set; }

        public IEnumerable<Colour> Colours { get; set; }
        public IEnumerable<Size> Sizes { get; set; }


    }
}
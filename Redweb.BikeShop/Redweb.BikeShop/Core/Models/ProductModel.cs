using System.ComponentModel.DataAnnotations;

namespace Redweb.BikeShop.Core.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public CategoryModel Category { get; set; }
        public SubcategoryModel Subcategory { get; set; }
        public ProductModelModel Model { get; set; }
        public decimal Price { get; set; }
        public ColourModel Colour { get; set; }
        public SizeModel Size { get; set; }
        public string Description { get; set; }
    }
}
using Redweb.BikeShop.Core.Models;

namespace Redweb.BikeShop.Core.ViewModels
{
    public class ProductDetailViewModel
    {
        public ProductModel ProductDetail { get; set; }
        public string ColourText { get; set; }
        public string SizeText { get; set; }
        public bool IsFromSearch { get; set; }
    }
}
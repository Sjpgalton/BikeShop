using Redweb.BikeShop.Core.Models;
using System.Collections.Generic;

namespace Redweb.BikeShop.Core.ViewModels
{
    public class AllProductsViewModel
    {
        public IEnumerable<ProductModel> AllProducts { get; set; }
        public bool ShowActions { get; set; }
        public string SearchTerm { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
using Redweb.BikeShop.Core.Models;
using System.Collections.Generic;

namespace Redweb.BikeShop.Core.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> AllProducts { get; set; }
    }
}
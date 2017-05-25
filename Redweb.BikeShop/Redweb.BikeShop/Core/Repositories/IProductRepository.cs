using System.Collections.Generic;
using Redweb.BikeShop.Core.Models;

namespace Redweb.BikeShop.Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
    }
}
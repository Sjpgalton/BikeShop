using System.Collections.Generic;
using Redweb.BikeShop.Core.Models;

namespace Redweb.BikeShop.Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel GetSingleProduct(int productId);
        void Add(ProductModel gig);
        void Complete();
    }
}
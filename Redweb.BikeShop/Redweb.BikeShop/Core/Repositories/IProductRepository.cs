using Redweb.BikeShop.Core.Models;
using System.Collections.Generic;

namespace Redweb.BikeShop.Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel GetSingleProduct(int productId);
        void Add(ProductModel product);
        void UpdateProduct(int existingProductId, ProductModel updatedProduct);
        void DeleteProduct(int id);
        void Complete();
        
    }
}
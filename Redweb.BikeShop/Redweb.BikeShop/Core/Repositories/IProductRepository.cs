using Redweb.BikeShop.Core.Models;
using Redweb.BikeShop.Core.ViewModels;
using System.Collections.Generic;

namespace Redweb.BikeShop.Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAllProducts();
        IEnumerable<ProductModel> SearchAllProducts(string query = null, 
            SearchSortTypes sortType = SearchSortTypes.Default);
        ProductModel GetSingleProduct(int productId);
        void Add(ProductModel product);
        void UpdateProduct(int existingProductId, ProductModel updatedProduct);
        void DeleteProduct(int id);
        void Complete();
        
    }
}
using AutoMapper;
using Redweb.BikeShop.Core;
using Redweb.BikeShop.Core.Models;
using Redweb.BikeShop.Core.Models.DatabaseModels;
using Redweb.BikeShop.Core.Repositories;
using Redweb.BikeShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;

namespace Redweb.BikeShop.Persistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IApplicationDbContext _context;

        public ProductRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>IEnumerable&lt;Product&gt;.</returns>
        public IEnumerable<ProductModel> GetAllProducts()
        {
            var allProducts = _context.Products
                .Include(product => product.Category)
                .Include(product => product.Subcategory)
                .Include(product => product.Model)
                .Include(product => product.Colour)
                .Include(product => product.Size)
                .OrderBy(product => product.Id)
                .ToList();

            return allProducts.Select(Mapper.Map<Product, ProductModel>);
        }

        public IEnumerable<ProductModel> SearchAllProducts(string query = null, SearchSortTypes sortType = SearchSortTypes.Default)
        {
            var allProducts = _context.Products
                .Include(product => product.Category)
                .Include(product => product.Subcategory)
                .Include(product => product.Model)
                .Include(product => product.Colour)
                .Include(product => product.Size)
                .OrderBy(product => product.Id)
                .ToList();

            if (!String.IsNullOrWhiteSpace(query))
            {
                allProducts = allProducts
                    .Where(product =>
                        product.Category.Name.Contains(query) ||
                        product.Subcategory.Name.Contains(query) ||
                        product.Model.Name.Contains(query) ||
                        product.Name.Contains(query) ||
                        product.Code.Contains(query))
                        .ToList();
            }

            if (sortType != SearchSortTypes.Default)
            {
                allProducts = SortedProductList(allProducts, sortType);
            }

            return allProducts.Select(Mapper.Map<Product, ProductModel>);
        }

        /// <summary>
        /// Gets the single product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>Product.</returns>
        public ProductModel GetSingleProduct(int productId)
        {
            var singleproduct = _context.Products
                .Include(product => product.Category)
                .Include(product => product.Subcategory)
                .Include(product => product.Model)
                .Include(product => product.Colour)
                .Include(product => product.Size)
                .SingleOrDefault(product => product.Id == productId);

            return Mapper.Map<ProductModel>(singleproduct);
        }

        public void Add(ProductModel newProduct)
        {
            var entityProduct = Mapper.Map<Product>(newProduct);

            _context.Products.Add(entityProduct);
        }

        public void UpdateProduct(int existingProductId, ProductModel updatedProduct)
        {
            var existingItem = GetSingleDatabaseItem(existingProductId);
            Mapper.Map(updatedProduct, existingItem);
            Complete();
        }

        public void DeleteProduct(int id)
        {
            var product = GetSingleDatabaseItem(id);
            _context.Products.Remove(product);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        private Product GetSingleDatabaseItem(int id)
        {
            return _context.Products
                .Include(product => product.Category)
                .Include(product => product.Subcategory)
                .Include(product => product.Model)
                .Include(product => product.Colour)
                .Include(product => product.Size)
                .SingleOrDefault(product => product.Id == id);
        }

        private static List<Product> SortedProductList(List<Product> allProducts, SearchSortTypes sortType)
        {
            switch (sortType)
            {
                case SearchSortTypes.Category:
                    return allProducts.OrderBy(product => product.Category.Name).ToList();
                case SearchSortTypes.Code:
                    return allProducts.OrderBy(product => product.Code).ToList();
                case SearchSortTypes.Model:
                    return allProducts.OrderBy(product => product.Model.Name).ToList();
                case SearchSortTypes.Name:
                    return allProducts.OrderBy(product => product.Name).ToList();
                case SearchSortTypes.Subcategory:
                    return allProducts.OrderBy(product => product.Subcategory.Name).ToList();
                default:
                    return allProducts;
            }

        }
    }
}
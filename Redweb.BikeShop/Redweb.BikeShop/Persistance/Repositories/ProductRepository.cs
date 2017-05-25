﻿using Redweb.BikeShop.Core;
using Redweb.BikeShop.Core.Models;
using Redweb.BikeShop.Core.Repositories;
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
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products
                .Include(product => product.Category)
                .Include(product => product.Subcategory)
                .Include(product => product.Model)
                .Include(product => product.Colour)
                .Include(product => product.Size)
                .OrderBy(product => product.Id)
                .ToList();
        }

        /// <summary>
        /// Gets the single product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>Product.</returns>
        public Product GetSingleProduct(int productId)
        {
            return _context.Products
                .Include(product => product.Category)
                .Include(product => product.Subcategory)
                .Include(product => product.Model)
                .Include(product => product.Colour)
                .Include(product => product.Size)
                .SingleOrDefault(product => product.Id == productId);
        }
    }
}
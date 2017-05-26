using AutoMapper;
using Redweb.BikeShop.Core;
using Redweb.BikeShop.Core.Models;
using Redweb.BikeShop.Core.Models.DatabaseModels;
using Redweb.BikeShop.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Redweb.BikeShop.Persistance.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IApplicationDbContext _context;

        public CategoriesRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            var allCategories = _context.Categories.ToList();

            return allCategories.Select(Mapper.Map<Category, CategoryModel>);
        }

        public CategoryModel GetSingleCategory(int id)
        {
            var singleCategopry = _context.Categories
                .Single(size => size.Id == id);

            return Mapper.Map<CategoryModel>(singleCategopry);
        }
    }
}
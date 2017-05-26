using AutoMapper;
using Redweb.BikeShop.Core;
using Redweb.BikeShop.Core.Models;
using Redweb.BikeShop.Core.Models.DatabaseModels;
using Redweb.BikeShop.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Redweb.BikeShop.Persistance.Repositories
{
    public class SubcategoriesRepository : ISubcategoriesRepository
    {
        private readonly IApplicationDbContext _context;

        public SubcategoriesRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SubcategoryModel> GetAllSubcategories()
        {
            var allSubcategories = _context.Subcategories.ToList();

            return allSubcategories.Select(Mapper.Map<Subcategory, SubcategoryModel>);
        }

        public SubcategoryModel GetSingleSubcategory(int id)
        {
            var singleSubcategory = _context.Subcategories
                .Single(size => size.Id == id);

            return Mapper.Map<SubcategoryModel>(singleSubcategory);
        }
    }
}
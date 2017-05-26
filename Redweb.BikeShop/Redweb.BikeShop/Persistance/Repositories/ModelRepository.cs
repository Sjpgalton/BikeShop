using AutoMapper;
using Redweb.BikeShop.Core;
using Redweb.BikeShop.Core.Models;
using Redweb.BikeShop.Core.Models.DatabaseModels;
using Redweb.BikeShop.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Redweb.BikeShop.Persistance.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly IApplicationDbContext _context;

        public ModelRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductModelModel> GetAllModels()
        {
            var allModels = _context.Models.ToList();

            return allModels.Select(Mapper.Map<Model, ProductModelModel>);
        }

        public ProductModelModel GetSingleModel(int id)
        {
            var singleModel = _context.Models
                .Single(size => size.Id == id);

            return Mapper.Map<ProductModelModel>(singleModel);
        }
    }
}
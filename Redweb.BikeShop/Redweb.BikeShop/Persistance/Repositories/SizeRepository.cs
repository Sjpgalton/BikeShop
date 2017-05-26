using AutoMapper;
using Redweb.BikeShop.Core;
using Redweb.BikeShop.Core.Models;
using Redweb.BikeShop.Core.Models.DatabaseModels;
using Redweb.BikeShop.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Redweb.BikeShop.Persistance.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private readonly IApplicationDbContext _context;

        public SizeRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SizeModel> GetAllSizes()
        {
            var allSizes = _context.Sizes.ToList();

            return allSizes.Select(Mapper.Map<Size, SizeModel>);
        }

        public SizeModel GetSingleSize(int id)
        {
            if (id == default(int))
                return null;

            var singleSize = _context.Sizes
                .Single(size => size.Id == id);

            return Mapper.Map<SizeModel>(singleSize);
        }
    }
}
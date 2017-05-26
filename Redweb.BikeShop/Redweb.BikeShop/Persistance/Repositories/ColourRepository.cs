using AutoMapper;
using Redweb.BikeShop.Core;
using Redweb.BikeShop.Core.Models;
using Redweb.BikeShop.Core.Models.DatabaseModels;
using Redweb.BikeShop.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Redweb.BikeShop.Persistance.Repositories
{
    public class ColourRepository : IColourRepository
    {
        private readonly IApplicationDbContext _context;

        public ColourRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ColourModel> GetAllColours()
        {
            var allCoulours = _context.Colours.ToList();

            return allCoulours.Select(Mapper.Map<Colour, ColourModel>);
        }

        public ColourModel GetSingleColour(int id)
        {
            if (id == default(int))
                return null;

            var singleColour = _context.Colours
                .Single(size => size.Id == id);

            return Mapper.Map<ColourModel>(singleColour);
        }
    }
}
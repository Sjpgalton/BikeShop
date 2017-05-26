using Redweb.BikeShop.Core.Models;
using System.Collections.Generic;

namespace Redweb.BikeShop.Core.Repositories
{
    public interface IColourRepository
    {
        IEnumerable<ColourModel> GetAllColours();
        ColourModel GetSingleColour(int id);
    }
}
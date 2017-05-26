using Redweb.BikeShop.Core.Models;
using System.Collections.Generic;

namespace Redweb.BikeShop.Core.Repositories
{
    public interface ISizeRepository
    {
        IEnumerable<SizeModel> GetAllSizes();
        SizeModel GetSingleSize(int id);
    }
}
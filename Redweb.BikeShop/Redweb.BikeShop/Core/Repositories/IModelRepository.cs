using Redweb.BikeShop.Core.Models;
using System.Collections.Generic;

namespace Redweb.BikeShop.Core.Repositories
{
    public interface IModelRepository
    {
        IEnumerable<ProductModelModel> GetAllModels();
        ProductModelModel GetSingleModel(int id);
    }
}
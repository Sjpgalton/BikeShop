using System.Collections.Generic;
using Redweb.BikeShop.Core.Models;

namespace Redweb.BikeShop.Core.Repositories
{
    public interface ICategoriesRepository
    {
        IEnumerable<CategoryModel> GetAllCategories();
        CategoryModel GetSingleCategory(int id);
    }
}
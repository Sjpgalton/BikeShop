﻿using Redweb.BikeShop.Core.Models;
using System.Collections.Generic;

namespace Redweb.BikeShop.Core.Repositories
{
    public interface ISubcategoriesRepository
    {
        IEnumerable<SubcategoryModel> GetAllSubcategories();
        SubcategoryModel GetSingleSubcategory(int id);
    }
}
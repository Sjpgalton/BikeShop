using System.Collections.Generic;
using Redweb.BikeShop.Core.Models;

namespace Redweb.BikeShop.Core.ViewModels
{
    public class SearchProductsViewModel
    {
        public PagedList.IPagedList<ProductModel> AllProducts { get; set; }
        public bool ShowActions { get; set; }
        public string SearchTerm { get; set; }
        public IEnumerable<SearchSortTypes> SortTypes { get; set; }
        public SearchSortTypes SortType { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public decimal NumberOfPages { get; set; }
    }
}
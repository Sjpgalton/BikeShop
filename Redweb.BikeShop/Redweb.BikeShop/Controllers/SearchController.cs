using PagedList;
using Redweb.BikeShop.Core.Repositories;
using Redweb.BikeShop.Core.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Redweb.BikeShop.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductRepository _productRepository;

        public SearchController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ActionResult MainSearch(int? page, string currentFilter, string query = null, SearchSortTypes sortType = SearchSortTypes.Default)
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                query = query.ToLower();
                page = 1;
            }

            var allProducts = _productRepository.SearchAllProducts(query, sortType);

            var pageSize = 40;
            var pageNumber = (page ?? 1);
            var numberOfPages = Math.Ceiling((decimal)allProducts.Count() / pageSize);
            

            var viewModel = new SearchProductsViewModel
            {
                SearchTerm = query,
                AllProducts = allProducts.ToPagedList(pageNumber, pageSize),
                PageSize = pageSize,
                PageNumber = pageNumber,
                NumberOfPages = numberOfPages,
                SortTypes = Enum.GetValues(typeof(SearchSortTypes)).Cast<SearchSortTypes>()
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Search(SearchProductsViewModel viewModel)
        {
            return RedirectToAction("MainSearch", "Search", new { query = viewModel.SearchTerm, viewModel.SortType });
        }
    }
}
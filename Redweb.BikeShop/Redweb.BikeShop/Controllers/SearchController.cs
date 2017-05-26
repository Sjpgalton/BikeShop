using Redweb.BikeShop.Core.Repositories;
using Redweb.BikeShop.Core.ViewModels;
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

        public ActionResult MainSearch(string query = null)
        {
            var allProducts = _productRepository.GetAllProducts();

            var viewModel = new AllProductsViewModel
            {
                SearchTerm = query,
                AllProducts = allProducts
            };

            return View(viewModel);
        }
    }
}
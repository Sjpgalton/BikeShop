using Redweb.BikeShop.Core.Repositories;
using System.Web.Mvc;
using Redweb.BikeShop.Core.ViewModels;

namespace Redweb.BikeShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ActionResult AllProducts()
        {
            var allProducts = _productRepository.GetAllProducts();

            return View(allProducts);
        }
    }
}
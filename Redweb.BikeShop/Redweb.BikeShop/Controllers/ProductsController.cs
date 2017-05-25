using Redweb.BikeShop.Core.Repositories;
using Redweb.BikeShop.Core.ViewModels;
using System.Web.Mvc;

namespace Redweb.BikeShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Gets all the products.
        /// </summary>
        /// <returns>ViewResult.</returns>
        public ActionResult AllProducts()
        {
            var allProducts = _productRepository.GetAllProducts();

            return View(allProducts);
        }

        /// <summary>
        /// Gets the Product details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ViewResult.</returns>
        public ActionResult ProductDetails(int id)
        {
            var productDetails = _productRepository.GetSingleProduct(id);

            if (productDetails == null)
                return HttpNotFound();

            var viewModel = new ProductDetailViewModel
            {
                ProductDetail = productDetails,
                ColourText = productDetails.Colour == null ? "N/A" : productDetails.Colour.Name,
                SizeText = productDetails.Size == null ? "N/A" : productDetails.Size.Name
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new AddProductViewModel
            {
                Genres = _genreRepository.GetAllGenres(),
                Heading = "Add a Gig"
            };

            return View("GigForm", viewModel);
        }
    }
}
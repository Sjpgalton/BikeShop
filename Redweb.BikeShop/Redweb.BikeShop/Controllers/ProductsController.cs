using Redweb.BikeShop.Core.Models;
using Redweb.BikeShop.Core.Repositories;
using Redweb.BikeShop.Core.ViewModels;
using System.Web.Mvc;

namespace Redweb.BikeShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IColourRepository _colourRepository;
        private readonly IModelRepository _modelRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly ISubcategoriesRepository _subcategoriesRepository;

        public ProductsController(IProductRepository productRepository, IColourRepository colourRepository,
            IModelRepository modelRepository, ICategoriesRepository categoriesRepository,
            ISizeRepository sizeRepository, ISubcategoriesRepository subcategoriesRepository)
        {
            _productRepository = productRepository;
            _colourRepository = colourRepository;
            _modelRepository = modelRepository;
            _categoriesRepository = categoriesRepository;
            _sizeRepository = sizeRepository;
            _subcategoriesRepository = subcategoriesRepository;
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

        /// <summary>
        /// Creates a product.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [Authorize]
        public ActionResult AddProduct()
        {
            var viewModel = new AddProductViewModel
            {
                PageHeading = "Add a Product",
                Colours = _colourRepository.GetAllColours(),
                Categories = _categoriesRepository.GetAllCategories(),
                Models = _modelRepository.GetAllModels(),
                Sizes = _sizeRepository.GetAllSizes(),
                Subcategories = _subcategoriesRepository.GetAllSubcategories()
            };

            return View("ProductForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(AddProductViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                viewModel.PageHeading = "Add a Product";
                viewModel.Colours = _colourRepository.GetAllColours();
                viewModel.Categories = _categoriesRepository.GetAllCategories();
                viewModel.Models = _modelRepository.GetAllModels();
                viewModel.Sizes = _sizeRepository.GetAllSizes();
                viewModel.Subcategories = _subcategoriesRepository.GetAllSubcategories();
                return View("ProductForm", viewModel);
            };

            var category = _categoriesRepository.GetSingleCategory(viewModel.CategoryId);
            var subCategory = _subcategoriesRepository.GetSingleSubcategory(viewModel.SubcategoryId);
            var model = _modelRepository.GetSingleModel(viewModel.ModelId);
            var colour = _colourRepository.GetSingleColour(viewModel.GetColourId());
            var size = _sizeRepository.GetSingleSize(viewModel.GetSizeId());


            var product = new ProductModel
            {
                Code = viewModel.ProductCode,
                Name = viewModel.ProductName,
                Category = category,
                Subcategory = subCategory,
                Model = model,
                Colour = colour,
                Size =  size,
                Price = viewModel.GetPriceDecimalValue(),
                Description = viewModel.Description
            };

            _productRepository.Add(product);
            _productRepository.Complete();

            return RedirectToAction("AllProducts", "Products");
        }
    }
}
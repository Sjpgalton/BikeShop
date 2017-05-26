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

            var viewModel = new AllProductsViewModel
            {
                AllProducts = allProducts,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View(viewModel);
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
            var viewModel = new ProductViewModel
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
        public ActionResult AddProduct(ProductViewModel viewModel)
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

        [Authorize]
        public ActionResult EditDetails(int id)
        {
            var product = _productRepository.GetSingleProduct(id);

            if (product == null)
                return HttpNotFound();
            
            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                PageHeading = "Edit a Product",
                Colours = _colourRepository.GetAllColours(),
                Categories = _categoriesRepository.GetAllCategories(),
                Models = _modelRepository.GetAllModels(),
                Sizes = _sizeRepository.GetAllSizes(),
                Subcategories = _subcategoriesRepository.GetAllSubcategories(),
                ColourId = product.Colour == null ? 0 : product.Colour.Id,
                SizeId = product.Size == null ? 0 : product.Size.Id,
                SubcategoryId = product.Subcategory.Id,
                CategoryId = product.Category.Id,
                ModelId = product.Model.Id,
                ProductName = product.Name,
                ProductCode = product.Code,
                Description = product.Description,
                Price = product.Price.ToString("0.00")
            };

            return View("ProductForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.PageHeading = "Edit a Product";
                viewModel.Colours = _colourRepository.GetAllColours();
                viewModel.Categories = _categoriesRepository.GetAllCategories();
                viewModel.Models = _modelRepository.GetAllModels();
                viewModel.Sizes = _sizeRepository.GetAllSizes();
                viewModel.Subcategories = _subcategoriesRepository.GetAllSubcategories();
                return View("ProductForm", viewModel);
            }

            var newCategory = _categoriesRepository.GetSingleCategory(viewModel.CategoryId);
            var newSubcategory = _subcategoriesRepository.GetSingleSubcategory(viewModel.SubcategoryId);
            var newModel = _modelRepository.GetSingleModel(viewModel.ModelId);
            var newColour = _colourRepository.GetSingleColour(viewModel.GetColourId());
            var newSize = _sizeRepository.GetSingleSize(viewModel.GetSizeId());

            var existingProduct = _productRepository.GetSingleProduct(viewModel.Id);

            if (existingProduct == null)
                return HttpNotFound();

            var updatedProduct = new ProductModel
            {
                Id = viewModel.Id,
                Code = viewModel.ProductCode,
                Name = viewModel.ProductName,
                Price = viewModel.GetPriceDecimalValue(),
                Description = viewModel.Description,
                Category = newCategory,
                Subcategory = newSubcategory,
                Model = newModel,
                Colour = newColour,
                Size = newSize,
            };

            _productRepository.UpdateProduct(existingProduct.Id, updatedProduct);

            return RedirectToAction("AllProducts", "Products");
        }
    }
}
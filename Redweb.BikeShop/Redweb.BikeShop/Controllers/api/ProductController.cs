using Redweb.BikeShop.Core.Repositories;
using System.Web.Http;

namespace Redweb.BikeShop.Controllers.Api
{
    [Authorize]
    public class ProductsController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var existingProduct = _productRepository.GetSingleProduct(id);

            if (existingProduct == null)
                return NotFound();

            _productRepository.DeleteProduct(id);
            _productRepository.Complete();

            return Ok();
        }
    }
}

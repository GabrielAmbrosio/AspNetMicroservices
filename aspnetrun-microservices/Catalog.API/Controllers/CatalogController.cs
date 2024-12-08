using Catalog.API.Entities;
using Catalog.API.Repositories.Product;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("apirecipe/[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProducts([FromServices] IProductRepository productRepository)
        {
            var products = await productRepository.GetProducts();

            if (products == null)
                return NotFound(); 

            return Ok(products);
        }
    }
}

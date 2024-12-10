using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BasketController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Consumes("application/json")]
        [Produces("application/json")]
        //[ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        /*public async Task<ActionResult<Product>> GetProducts([FromServices] IProductRepository productRepository)
        {
            var products = await productRepository.GetProducts();

            return products == null ? NotFound() : Ok(products);
        }*/
    }
}

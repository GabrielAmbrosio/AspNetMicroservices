using Asp.Versioning;
using AutoMapper;
using Catalog.API.Dtos;
using Catalog.API.Entities;
using Catalog.API.Repositories.Product;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProducts([FromServices] IProductRepository productRepository)
        {
            var products = await productRepository.GetProducts();

            return products == null ? NotFound() : Ok(products);
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductById([FromRoute] string id, [FromServices] IProductRepository productRepository)
        {
            var product = await productRepository.GetProductById(id);

            return product == null ? NotFound() : Ok(product);
        }

        [HttpGet("{category}")]
        [MapToApiVersion("1.0")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductsByCategory([FromRoute] string category, [FromServices] IProductRepository productRepository)
        {
            var products = await productRepository.GetProductsByCategory(category);

            return products == null ? NotFound() : Ok(products);
        }

        [HttpGet("{name}")]
        [MapToApiVersion("1.0")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductByName([FromRoute] string name, [FromServices] IProductRepository productRepository)
        {
            var products = await productRepository.GetProductByName(name);

            return products == null ? NotFound() : Ok(products);
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> AddProduct([FromBody] ProductDto productDto, [FromServices] IProductRepository productRepository, [FromServices] IMapper mapper)
        {

            var mappedProduct = mapper.Map<Product>(productDto);

            var product = await productRepository.AddProduct(mappedProduct);

            return product == null ? NotFound() : Ok(product.Id);
        }


        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> DeleteProduct([FromRoute] string id, [FromServices] IProductRepository productRepository)
        {
            var isDeleted = await productRepository.DeleteProduct(id);

            return isDeleted == false ? NotFound() : Ok(isDeleted);
        }


        [HttpPut]
        [MapToApiVersion("1.0")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] ProductDto productDto, [FromServices] IProductRepository productRepository, [FromServices] IMapper mapper)
        {

            var mappedProduct = mapper.Map<Product>(productDto);

            var isUpdated = await productRepository.UpdateProduct(mappedProduct);

            return isUpdated == false ? NotFound() : Ok(isUpdated);
        }
    }
}

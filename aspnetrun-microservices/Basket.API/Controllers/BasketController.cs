using Asp.Versioning;
using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BasketController : ControllerBase
    {
        [HttpGet("{userName}", Name = "GetBasket")]
        [MapToApiVersion("1.0")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ShoppingCart>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShoppingCart>> GetBasket([FromRoute] string userName, [FromServices] IBasketRepository basketRepository)
        {
            var basket = await basketRepository.GetBasket(userName);

            return basket == await basketRepository.GetBasket(userName) ? new ShoppingCart(userName) : Ok(basket);
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ShoppingCart>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket, [FromServices] IBasketRepository basketRepository)
        {
            return await basketRepository.UpdateBasket(basket) == null ? NotFound() : Ok(basket);
        }

        [HttpDelete]
        [MapToApiVersion("1.0")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ShoppingCart>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShoppingCart>> DeleteBasket([FromRoute] string userName, [FromServices] IBasketRepository basketRepository)
        {
            await basketRepository.DeleteBasket(userName);

            return Ok();
        }
    }
}

using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        public readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache =  redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }
    }
}

namespace Basket.API.Extensions
{
    public static class RedisDbServiceExtensions
    {
        public static void AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetValue<string>("RedisConnection:ConnectionString");
            });
        }
    }
}

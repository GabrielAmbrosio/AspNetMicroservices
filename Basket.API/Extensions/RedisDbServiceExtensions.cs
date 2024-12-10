using StackExchange.Redis;

namespace Basket.API.Extensions
{
    public static class RedisDbServiceExtensions
    {
        public static void AddRedis(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                return ConnectionMultiplexer.Connect(configuration.GetValue<string>("RedisConnection:ConnectionString"));
            });
        }
    }
}

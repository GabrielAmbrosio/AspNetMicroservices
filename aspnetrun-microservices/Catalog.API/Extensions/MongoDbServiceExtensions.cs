using MongoDB.Driver;

namespace Catalog.API.Extensions
{
    public static class MongoDbServiceExtensions
    {
        public static void AddMongoDatabase(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                return new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            });

            services.AddSingleton<IMongoDatabase>(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                var configuration = sp.GetRequiredService<IConfiguration>();
                return client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            });
        }
    }
}

using Basket.API.Repositories;

namespace Basket.API.Extensions
{
    public static class RepositoriesServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBasketRepository, BasketRepository>();
        }
    }
}

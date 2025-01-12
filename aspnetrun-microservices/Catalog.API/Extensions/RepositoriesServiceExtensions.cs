﻿using Catalog.API.Data;
using Catalog.API.Repositories.Product;

namespace Catalog.API.Extensions
{
    public static class RepositoriesServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<CatalogContext>();

            services.AddScoped<IProductRepository,ProductRepository>();
        }
    }
}

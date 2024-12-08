using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public CatalogContext(IMongoDatabase database, IConfiguration configuration)
        {
            var collectionName = configuration.GetValue<string>("DatabaseSettings:CollectionName");
            
            Products = database.GetCollection<Product>(collectionName);

            CatalogContextSeed.Seed(Products);
        }
    }
}

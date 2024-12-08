using Catalog.API.Data;
using MongoDB.Driver;
using System.Xml.Linq;

namespace Catalog.API.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Entities.Product> AddProduct(Entities.Product product)
        {
            await _context.Products.InsertOneAsync(product);

            return product;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            // Using explicit filter for practises purpose only
            var filter = Builders<Entities.Product>.Filter.Eq(p => p.Id, id);

            var result = await _context.Products.DeleteOneAsync(filter);

            bool deleted = result.DeletedCount > 0;

            return deleted;
        }

        public async Task<IEnumerable<Entities.Product>> GetProductsByCategory(string category)
        {
           return await _context.Products.Find(p => p.Category == category).ToListAsync();
        }

        public async Task<Entities.Product> GetProductById(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();  
        }

        public async Task<Entities.Product> GetProductByName(string name)
        {
            return await _context.Products.Find(p => p.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Product>> GetProducts()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Entities.Product product)
        {
            var replacedProduct =  await _context.Products.ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);

            return replacedProduct.IsAcknowledged && replacedProduct.ModifiedCount > 0;
        }
    }
}

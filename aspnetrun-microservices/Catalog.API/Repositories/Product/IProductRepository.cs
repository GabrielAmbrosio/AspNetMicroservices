namespace Catalog.API.Repositories.Product
{
    public interface IProductRepository
    {
        Task<IEnumerable<Entities.Product>> GetProducts();

        Task<Entities.Product> GetProductById(string id);

        Task<Entities.Product> GetProductByName(string name);

        Task<IEnumerable<Entities.Product>> GetProductsByCategory(string category);

        Task<Entities.Product> AddProduct(Entities.Product product);

        Task<bool> UpdateProduct(Entities.Product product);

        Task<bool> DeleteProduct(string id);
    }
}

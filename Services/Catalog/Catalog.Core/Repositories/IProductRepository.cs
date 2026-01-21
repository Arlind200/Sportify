using Catalog.CORE.Entities;
using Catalog.CORE.Specs;

namespace Catalog.CORE.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(string id);
        Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams);
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<IEnumerable<Product>> GetProductsByBrand(string brandName);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string product);
    }
}

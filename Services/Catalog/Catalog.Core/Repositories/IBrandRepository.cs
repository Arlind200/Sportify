using Catalog.CORE.Entities;

namespace Catalog.CORE.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<ProductBrand>> GetAllBrands();
    }
}

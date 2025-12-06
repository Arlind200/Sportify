using Catalog.CORE.Entities;

namespace Catalog.CORE.Repositories
{
    public interface ITypeRepository
    {
        Task<IEnumerable<ProductType>> GetAllTypes();
    }
}

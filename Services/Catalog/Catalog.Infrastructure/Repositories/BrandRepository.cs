using Catalog.CORE.Entities;
using Catalog.CORE.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Catalog.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ICatalogContext _context;

        public BrandRepository(ICatalogContext context)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            _context = context;
        }

        public async Task<IEnumerable<ProductBrand>> GetAllBrands()
        {
            return await _context
                .Brands
                .Find(b => true)
                .ToListAsync();
        }
    }
}

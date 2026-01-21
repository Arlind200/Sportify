using Catalog.Application.Sorting;
using Catalog.CORE.Entities;
using Catalog.CORE.Repositories;
using Catalog.CORE.Specs;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

namespace Catalog.Infrastructure.Repositories
{


    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;
        private readonly ISortStrategyFactory _sortStrategyFactory;

        public ProductRepository(ICatalogContext context, ISortStrategyFactory sortStrategyFactory)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentNullException.ThrowIfNull(sortStrategyFactory, nameof(sortStrategyFactory));
            _context = context;
            _sortStrategyFactory = sortStrategyFactory;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            await _context
               .Products
               .InsertOneAsync(product);

            return product;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var deleteProduct = await _context
                .Products
                .DeleteOneAsync(p => p.Id == id);

            return deleteProduct.IsAcknowledged && deleteProduct.DeletedCount > 0;

        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updatedProduct = await _context
                .Products
                .ReplaceOneAsync(p => p.Id == product.Id, product);

            return updatedProduct.IsAcknowledged && updatedProduct.ModifiedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context
                 .Products
                 .Find(p => true)
                 .ToListAsync();
        }

        public Task<Product> CreateProduct(ProductRepository product)
        {
            throw new NotImplementedException();
        }


        public async Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams)
        {
            var builder = Builders<Product>.Filter;
            var filter = builder.Empty;

            if (!string.IsNullOrEmpty(catalogSpecParams.Search))
            {
                filter = filter & builder.Where(p => p.Name.ToLower().Contains(catalogSpecParams.Search.ToLower()));
            }

            if (!string.IsNullOrEmpty(catalogSpecParams.BrandId))
            {
                var brandfilter = builder.Eq(p => p.Brand.Id, catalogSpecParams.BrandId);

                filter &= brandfilter;
            }

            if (!string.IsNullOrEmpty(catalogSpecParams.TypeId))
            {
                var typeFilter = builder.Eq(p => p.Type.Id, catalogSpecParams.TypeId);

                filter &= typeFilter;
            }

            var totalItems = await _context.Products.CountDocumentsAsync(filter);
            var data = await DataFilter(catalogSpecParams, filter);

            return new Pagination<Product>
                (
                catalogSpecParams.PageIndex,
                catalogSpecParams.PageSize,
                (int)totalItems,
                data
                );

        }

        private async Task<IReadOnlyList<Product>> DataFilter(CatalogSpecParams catalogSpecParams, FilterDefinition<Product> filter)
        {
            var sortDefinition = Builders<Product>.Sort.Ascending("name"); //default

            if (!string.IsNullOrEmpty(catalogSpecParams.Sort))
            {
                switch (catalogSpecParams.Sort)
                {
                    case "priceAsc":
                        sortDefinition = Builders<Product>.Sort.Ascending(p => p.Price);
                        break;
                    case "priceDesc":
                        sortDefinition = Builders<Product>.Sort.Descending(p => p.Price);
                        break;
                    default:
                        sortDefinition = Builders<Product>.Sort.Ascending(p => p.Name);
                        break;
                }


            }

            return await _context
                .Products
                .Find(filter)
                .Sort(sortDefinition)
                .Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex - 1))
                .Limit(catalogSpecParams.PageSize)
                .ToListAsync();


        }

        public async Task<IEnumerable<Product>> GetProductsByBrand(string brandName)
        {
            return await _context
                .Products
                .Find(p => p.Brand.Name.ToLower() == brandName.ToLower())
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await _context
                 .Products
                 .Find(p => p.Name.ToLower() == name.ToLower())
                 .ToListAsync();
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _context
                .Products
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}

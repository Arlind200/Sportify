using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.CORE.Entities;
using Catalog.CORE.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandHandler, ProductResponse>
    {
        private IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public async Task<ProductResponse> Handle(CreateProductCommandHandler request, CancellationToken cancellationToken)
        {
            var productEntity = ProductMapper.Mapper.Map<Product>(request);

            if (productEntity == null)
            {
                throw new ApplicationException("There is an issue with mapping while creating a new product");
            }

            var newProduct = await _productRepository.CreateProduct(productEntity);
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(newProduct);

            return productResponse;

        }
    }
}

using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.CORE.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductsByNameHandler : IRequestHandler<GetProductsByNameQuery, IList<ProductResponse>>
    {
        private IProductRepository _productRepository;
        public GetProductsByNameHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        async Task<IList<ProductResponse>> IRequestHandler<GetProductsByNameQuery, IList<ProductResponse>>.Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetProductsByName(request.Name);
            var productResponseList = ProductMapper.Mapper.Map<IList<ProductResponse>>(productList);
            return productResponseList;
        }
    }
}

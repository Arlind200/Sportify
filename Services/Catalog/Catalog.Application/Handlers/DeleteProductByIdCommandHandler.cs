using Catalog.Application.Commands;
using Catalog.CORE.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{

    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, bool>
    {
        private IProductRepository _productRepository;

        public DeleteProductByIdCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.DeleteProduct(request.Id);

            return result;
        }
    }
}

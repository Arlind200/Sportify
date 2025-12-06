using Catalog.Application.Commands;
using Catalog.CORE.Entities;
using Catalog.CORE.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var result = await _productRepository.UpdateProduct(new Product
            {
                Id = request.Name,
                Name = request.Name,
                Summary = request.Summary,
                Description = request.Description,
                ImageFile = request.ImageFile,
                Price = request.Price,
                Brand = request.Brand,
                Type = request.Type

            });
            return result;
        }
    }
}

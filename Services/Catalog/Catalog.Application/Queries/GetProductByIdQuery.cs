using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;
public class GetProductByIdQuery : IRequest<ProductResponse>
{
    public string Id { get; init; }
    public GetProductByIdQuery(string id)
    {
        Id = id;
    }
}

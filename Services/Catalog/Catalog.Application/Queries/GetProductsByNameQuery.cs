using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;
public class GetProductsByNameQuery : IRequest<IList<ProductResponse>>
{
    public string Name { get; init; }
    public GetProductsByNameQuery(string name)
    {
        Name = name;
    }
}

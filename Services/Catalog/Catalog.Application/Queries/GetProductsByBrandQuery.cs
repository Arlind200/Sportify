using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;
public class GetProductsByBrandQuery : IRequest<IList<ProductResponse>>
{
    public string BrandName { get; init; }

    public GetProductsByBrandQuery(string brandName)
    {
        BrandName = brandName;
    }
}

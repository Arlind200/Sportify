using MediatR;

namespace Catalog.Application.Commands;
public class DeleteProductByIdCommand : IRequest<bool>
{
    public string Id { get; init; }

    public DeleteProductByIdCommand(string id)
    {
        Id = id;
    }
}

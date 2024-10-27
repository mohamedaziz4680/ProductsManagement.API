using MediatR;

namespace ProductsManagement.Application.Commands;

public class RemoveProductCommand : IRequest
{
    public Guid ProductId { get; set; }

    public RemoveProductCommand(Guid productId)
    {
        ProductId = productId;
    }
}
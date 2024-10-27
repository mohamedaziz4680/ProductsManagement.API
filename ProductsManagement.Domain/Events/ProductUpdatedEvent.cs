using MediatR;

namespace ProductsManagement.Domain.Events;

public class ProductUpdatedEvent : INotification
{
    public Guid ProductId { get; }
    public bool IsAdded { get; }

    public ProductUpdatedEvent(Guid productId, bool isAdded)
    {
        ProductId = productId;
        IsAdded = isAdded;
    }
}
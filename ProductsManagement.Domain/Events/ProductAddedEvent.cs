using MediatR;

namespace ProductsManagement.Domain.Events;

public class ProductAddedEvent : INotification
{
    public Guid ProductId { get; }
    public Guid CategoryId { get; }

    public ProductAddedEvent(Guid productId, Guid categoryId)
    {
        ProductId = productId;
        CategoryId = categoryId;
    }
}
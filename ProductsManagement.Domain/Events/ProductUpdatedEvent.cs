using MediatR;

namespace ProductsManagement.Domain.Events;

public class ProductUpdatedEvent : INotification
{
    public Guid CategoryId { get; }
    public bool IsAdded { get; }

    public ProductUpdatedEvent(Guid categoryId, bool isAdded)
    {
        CategoryId = categoryId;
        IsAdded = isAdded;
    }
}
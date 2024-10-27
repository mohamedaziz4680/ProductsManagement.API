using ProductsManagement.Application.Repositories;
using ProductsManagement.Domain.Events;
using MediatR;

namespace ProductsManagement.Application.EventHandlers;

public class ProductUpdatedEventHandler : INotificationHandler<ProductUpdatedEvent>
{
    private readonly ICategoryRepository _categoryRepository;

    public ProductUpdatedEventHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(ProductUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(notification.ProductId);

        if (notification.IsAdded)
            category.IncrementProductCount();
        else
            category.DecrementProductCount();
        
        await _categoryRepository.UpdateAsync(category); 
    }
}
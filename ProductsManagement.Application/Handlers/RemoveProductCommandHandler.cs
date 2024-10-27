using MediatR;
using ProductsManagement.Application.Commands;
using ProductsManagement.Application.Repositories;
using ProductsManagement.Domain.Events;

namespace ProductsManagement.Application.Handlers;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IMediator _mediator;

    public RemoveProductCommandHandler(IProductRepository productRepository, IMediator mediator)
    {
        _productRepository = productRepository;
        _mediator = mediator;
    }

    public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId);
        if (product != null)
        {
            await _productRepository.RemoveAsync(product);
            
            var productUpdatedEvent = new ProductUpdatedEvent(product.Id, isAdded: false);
            await _mediator.Publish(productUpdatedEvent, cancellationToken);
        }
        return;
    }
}
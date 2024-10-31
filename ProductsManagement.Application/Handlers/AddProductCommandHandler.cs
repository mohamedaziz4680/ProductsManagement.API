using MediatR;
using ProductsManagement.Application.Commands;
using ProductsManagement.Application.Repositories;
using ProductsManagement.Domain.Events;
using ProductsManagement.Domain.Products;

namespace ProductsManagement.Application.Handlers;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly IMediator _mediator;

    public AddProductCommandHandler(IProductRepository productRepository, IMediator mediator)
    {
        _productRepository = productRepository;
        _mediator = mediator;
    }

    public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(Guid.NewGuid(), request.Name, new Price(request.Price, request.Currency), request.CategoryId);
        await _productRepository.AddAsync(product);
        
        
        var productUpdatedEvent = new ProductUpdatedEvent(request.CategoryId, isAdded: true);
        await _mediator.Publish(productUpdatedEvent, cancellationToken);
        
        return product.Id;
    }
}
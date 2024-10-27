using MediatR;
using ProductsManagement.Domain.Products;

namespace ProductsManagement.Application.Products.Commands;

public class CreateProductCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public decimal PriceValue { get; set; }
    public string PriceCurrency { get; set; }
    public Guid CategoryId { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
            Guid.NewGuid(),
            request.Name,
            new Price(request.PriceValue, request.PriceCurrency),
            request.CategoryId
        );

        // Save product to database (pseudo-code, replace with repository implementation)
        // await _productRepository.AddAsync(product);

        return product.Id;
    }
}
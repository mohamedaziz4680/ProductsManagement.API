using MediatR;
using ProductsManagement.Application.Repositories;
using ProductsManagement.Domain.Products;

namespace ProductsManagement.Application.Products.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public Guid ProductId { get; set; }
}

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId);

        return product;
    }
}
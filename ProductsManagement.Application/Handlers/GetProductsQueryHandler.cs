using MediatR;
using ProductsManagement.API.DTOs;
using ProductsManagement.Application.Queries;
using ProductsManagement.Application.Repositories;

namespace ProductsManagement.Application.Handlers;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(p => new ProductDto 
        { 
            Id = p.Id, 
            Name = p.Name, 
            Price = p.Price.Value, 
            Currency = p.Price.Currency 
        });
    }
}
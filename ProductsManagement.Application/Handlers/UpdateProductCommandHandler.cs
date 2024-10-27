using MediatR;
using ProductsManagement.Application.Commands;
using ProductsManagement.Application.Repositories;

namespace ProductsManagement.Application.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product == null)
            return false;

        product.Name = request.Name;
        product.Price.Value = request.Price;
        product.Price.Currency = request.Currency;
        product.CategoryId = request.CategoryId;

        await _productRepository.UpdateAsync(product);
        return true;
    }
}

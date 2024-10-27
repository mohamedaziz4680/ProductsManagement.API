using MediatR;
using ProductsManagement.Domain.Products;

namespace ProductsManagement.Application.Commands;

public class UpdateProductCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
    public Guid CategoryId { get; set; } 

    public UpdateProductCommand(string name, decimal price, string currency, Guid categoryId)
    {
        Name = name;
        Price = price;
        Currency = currency;
        CategoryId = categoryId;
    }

}
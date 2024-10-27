using MediatR;

namespace ProductsManagement.Application.Commands;

public class AddProductCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
    public Guid CategoryId { get; set; } 

    public AddProductCommand(string name, decimal price, string currency, Guid categoryId)
    {
        Name = name;
        Price = price;
        Currency = currency;
        CategoryId = categoryId;
    }
}
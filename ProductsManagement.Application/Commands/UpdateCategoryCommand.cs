using MediatR;

namespace ProductsManagement.Application.Commands;

public class UpdateCategoryCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
using MediatR;

namespace ProductsManagement.Application.Commands;

public class AddCategoryCommand : IRequest<Guid> // Returns the new category ID
{
    public string Name { get; set; }

    public AddCategoryCommand(string name)
    {
        Name = name;
    }
}
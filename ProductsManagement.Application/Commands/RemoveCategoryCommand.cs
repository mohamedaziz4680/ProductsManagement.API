using MediatR;

namespace ProductsManagement.Application.Commands;

public class RemoveCategoryCommand : IRequest
{
    public Guid CategoryId { get; set; }

    public RemoveCategoryCommand(Guid categoryId)
    {
        CategoryId = categoryId;
    }
}
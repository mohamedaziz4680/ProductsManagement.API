using MediatR;
using ProductsManagement.Domain.Categories;

namespace ProductsManagement.Application.Categories.Commands;

public class CreateCategoryCommand : IRequest<Guid>
{
    public string Name { get; set; }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(Guid.NewGuid(), request.Name);

        // Save category to database (pseudo-code, replace with repository implementation)
        // await _categoryRepository.AddAsync(category);

        return category.Id;
    }
}
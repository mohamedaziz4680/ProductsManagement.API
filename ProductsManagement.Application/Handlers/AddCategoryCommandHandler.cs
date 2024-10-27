using MediatR;
using ProductsManagement.Application.Commands;
using ProductsManagement.Application.Repositories;
using ProductsManagement.Domain.Categories;

namespace ProductsManagement.Application.Handlers;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Guid>
{
    private readonly ICategoryRepository _categoryRepository;

    public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Guid> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(Guid.NewGuid(), request.Name);
        await _categoryRepository.AddAsync(category);
        return category.Id;
    }
}
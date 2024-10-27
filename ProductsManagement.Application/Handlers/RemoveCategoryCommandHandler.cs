using MediatR;
using ProductsManagement.Application.Commands;
using ProductsManagement.Application.Repositories;

namespace ProductsManagement.Application.Handlers;

public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
        if (category == null)
        {
            throw new KeyNotFoundException("Category not found.");
        }

        await _categoryRepository.RemoveAsync(category);
        return;
    }
}
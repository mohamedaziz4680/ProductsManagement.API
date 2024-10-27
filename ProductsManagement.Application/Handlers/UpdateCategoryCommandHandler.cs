using MediatR;
using ProductsManagement.Application.Commands;
using ProductsManagement.Application.Repositories;

namespace ProductsManagement.Application.Handlers;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository repository)
    {
        _categoryRepository = repository;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category == null)
            return false;

        category.Name = request.Name;

        _categoryRepository.UpdateAsync(category);
        return true;
    }
}

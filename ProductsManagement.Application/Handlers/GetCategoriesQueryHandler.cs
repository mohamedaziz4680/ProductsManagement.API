using MediatR;
using ProductsManagement.API.DTOs;
using ProductsManagement.Application.Queries;
using ProductsManagement.Application.Repositories;

namespace ProductsManagement.Application.Handlers;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync();
        return categories.Select(c => new CategoryDto 
        { 
            Id = c.Id, 
            Name = c.Name, 
            ProductCount = c.ProductCount 
        });
    }
}
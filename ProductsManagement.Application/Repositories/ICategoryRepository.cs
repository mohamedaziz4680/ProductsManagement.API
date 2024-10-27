using ProductsManagement.Domain.Categories;

namespace ProductsManagement.Application.Repositories;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
    Task<Category> GetByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task UpdateAsync(Category category);
    Task RemoveAsync(Category category);
}
using ProductsManagement.Domain.Products;

namespace ProductsManagement.Application.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task UpdateAsync(Product product);
    Task RemoveAsync(Product product);
}
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductsManagement.Application.Repositories;
using ProductsManagement.Domain.Events;
using ProductsManagement.Domain.Products;

namespace ProductsManagement.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    private readonly IMediator _mediator; 

    public ProductRepository(AppDbContext context, IMediator mediator) 
    {
        _context = context;
        _mediator = mediator; 
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        //await _mediator.Publish(new ProductUpdatedEvent(product.Id, true));
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }
    
    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
    
    public async Task RemoveAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    
}
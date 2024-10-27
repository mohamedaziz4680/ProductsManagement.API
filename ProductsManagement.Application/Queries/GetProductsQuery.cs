using MediatR;
using ProductsManagement.API.DTOs;

namespace ProductsManagement.Application.Queries;

public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
{
}
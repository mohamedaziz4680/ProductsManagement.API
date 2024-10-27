using MediatR;
using ProductsManagement.API.DTOs;

namespace ProductsManagement.Application.Queries;

public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{
}
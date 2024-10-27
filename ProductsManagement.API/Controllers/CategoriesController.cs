using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.API.DTOs;
using ProductsManagement.Application.Commands;
using ProductsManagement.Application.Queries;

namespace ProductsManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : Controller
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
    {
        var query = new GetCategoriesQuery();
        var categories = await _mediator.Send(query);
        return Ok(categories);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Add([FromBody] AddCategoryCommand command)
    {
        var categoryId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id = categoryId }, categoryId);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");

        var result = await _mediator.Send(command);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        var command = new RemoveCategoryCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
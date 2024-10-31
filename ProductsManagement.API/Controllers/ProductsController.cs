using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.API.DTOs;
using ProductsManagement.Application.Commands;
using ProductsManagement.Application.Queries;

namespace ProductsManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : Controller
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var query = new GetProductsQuery();
        var products = await _mediator.Send(query);
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Add([FromBody] AddProductCommand command)
    {
        var productId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id = productId }, productId);
    }
    
    [HttpPost("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");

        var result = await _mediator.Send(command);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        var command = new RemoveProductCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}

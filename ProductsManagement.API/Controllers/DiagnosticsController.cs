using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.Application.Common.Commands;

namespace ProductsManagement.API.Controllers;

public class DiagnosticsController : Controller
{
    // GET
    private readonly IMediator _mediator;

    public DiagnosticsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("ping")]
    public async Task<IActionResult> Ping()
    {
        var result = await _mediator.Send(new PingCommand());
        return Ok(result);
    }
}
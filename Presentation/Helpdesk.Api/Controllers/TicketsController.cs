using Helpdesk.Contracts.Tickets;
using Helpdesk.Application.Tickets.Commands.CreateTicket;
using Helpdesk.Application.Tickets.Commands.ChangeStatus;
using Helpdesk.Application.Tickets.Queries.GetTickets;
using Helpdesk.Application.Tickets.Queries.GetTicketById;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Helpdesk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly IMediator _mediator;
    public TicketsController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<TicketResponse>> Create([FromBody] CreateTicketRequest req)
    {
        var result = await _mediator.Send(new CreateTicketCommand(req));
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}/status")]
    public async Task<IActionResult> ChangeStatus(Guid id, [FromBody] ChangeStatusRequest req)
    {
        await _mediator.Send(new ChangeStatusCommand(id, req));
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<TicketResponse>>> List(
        [FromQuery] string? status, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        var list = await _mediator.Send(new GetTicketsQuery(status, page, pageSize));
        return Ok(list);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TicketResponse>> GetById(Guid id)
    {
        var data = await _mediator.Send(new GetTicketByIdQuery(id));
        return data is null ? NotFound() : Ok(data);
    }
}

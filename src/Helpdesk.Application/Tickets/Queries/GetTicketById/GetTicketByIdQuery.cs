using MediatR;
using Helpdesk.Contracts.Tickets;

namespace Helpdesk.Application.Tickets.Queries.GetTicketById;

public record GetTicketByIdQuery(Guid Id) : IRequest<TicketResponse?>;

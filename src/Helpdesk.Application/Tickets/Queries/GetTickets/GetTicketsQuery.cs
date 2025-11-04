    using MediatR;
using Helpdesk.Contracts.Tickets;

namespace Helpdesk.Application.Tickets.Queries.GetTickets;

public record GetTicketsQuery(string? Status, int Page = 1, int PageSize = 20) : IRequest<IReadOnlyList<TicketResponse>>;

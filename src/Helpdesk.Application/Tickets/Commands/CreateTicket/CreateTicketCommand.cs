using MediatR;
using Helpdesk.Contracts.Tickets;

namespace Helpdesk.Application.Tickets.Commands.CreateTicket;

public record CreateTicketCommand(CreateTicketRequest Request) : IRequest<TicketResponse>;

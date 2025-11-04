using MediatR;
using Helpdesk.Contracts.Tickets;

namespace Helpdesk.Application.Tickets.Commands.ChangeStatus;

public record ChangeStatusCommand(Guid Id, ChangeStatusRequest Request) : IRequest<Unit>;

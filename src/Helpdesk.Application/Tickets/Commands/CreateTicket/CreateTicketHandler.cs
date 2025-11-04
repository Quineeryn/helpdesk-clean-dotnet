using Helpdesk.Application.Abstractions.Persistence;
using Helpdesk.Application.Mapping;
using Helpdesk.Contracts.Tickets;
using Helpdesk.Core.Entities;
using MediatR;

namespace Helpdesk.Application.Tickets.Commands.CreateTicket;

public sealed class CreateTicketHandler(
    ITicketRepository repo,
    IUnitOfWork uow
) : IRequestHandler<CreateTicketCommand, TicketResponse>
{
    public async Task<TicketResponse> Handle(CreateTicketCommand cmd, CancellationToken ct)
    {
        var r = cmd.Request;

        var entity = new Ticket(
            r.Title,
            r.Description,
            r.Priority.ToCore(),
            r.ReporterId
        );

        if (r.AssigneeId is Guid a) entity.AssignTo(a);
        if (r.DueAt is DateTimeOffset d) entity.Schedule(d);
        if (r.SprintId is Guid s) entity.AssignTo(entity.AssigneeId); // keep sprint via property set if needed

        // persist
        await repo.AddAsync(entity, ct);
        await uow.SaveChangesAsync(ct);

        return new TicketResponse(
            entity.Id,
            entity.Title,
            entity.Description,
            entity.Status.ToContractString(),
            entity.Priority.ToContractString(),
            entity.AssigneeId,
            entity.ReporterId,
            entity.SprintId,
            entity.DueAt,
            entity.CreatedAt
        );
    }
}

using Helpdesk.Application.Abstractions.Persistence;
using Helpdesk.Application.Mapping;
using MediatR;

namespace Helpdesk.Application.Tickets.Commands.ChangeStatus;

public sealed class ChangeStatusHandler(ITicketRepository repo, IUnitOfWork uow) : IRequestHandler<ChangeStatusCommand, Unit>
{
    public async Task<Unit> Handle(ChangeStatusCommand cmd, CancellationToken ct)
    {
        var entity = await repo.GetAsync(cmd.Id, ct) ?? throw new KeyNotFoundException("Ticket not found");
        entity.ChangeStatus(cmd.Request.Status.ToCore());
        await repo.UpdateAsync(entity, ct);
        await uow.SaveChangesAsync(ct);
        return Unit.Value;
    }
}

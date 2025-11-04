    using Helpdesk.Application.Abstractions.Persistence;
using Helpdesk.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.Persistence.Repositories;

public class TicketRepository(AppDbContext db) : ITicketRepository
{
    public Task<Ticket?> GetAsync(Guid id, CancellationToken ct = default) =>
        db.Tickets.Include(t => t.Comments).FirstOrDefaultAsync(x => x.Id == id, ct);

    public Task AddAsync(Ticket entity, CancellationToken ct = default)
    {
        db.Tickets.Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Ticket entity, CancellationToken ct = default)
    {
        db.Tickets.Update(entity);
        return Task.CompletedTask;
    }
}

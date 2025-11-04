using Helpdesk.Core.Entities;

namespace Helpdesk.Application.Abstractions.Persistence;

public interface ITicketRepository
{
    Task<Ticket?> GetAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Ticket entity, CancellationToken ct = default);
    Task UpdateAsync(Ticket entity, CancellationToken ct = default);
}

using Helpdesk.Application.Abstractions.Persistence;

namespace Helpdesk.Infrastructure.Persistence;

public class UnitOfWork(AppDbContext db) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken ct = default) => db.SaveChangesAsync(ct);
}

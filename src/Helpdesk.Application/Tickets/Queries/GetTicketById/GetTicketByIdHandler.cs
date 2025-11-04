using Dapper;
using MediatR;
using Helpdesk.Contracts.Tickets;
using Helpdesk.Application.Abstractions.Queries;

namespace Helpdesk.Application.Tickets.Queries.GetTicketById;

public sealed class GetTicketByIdHandler(IReadDbConnection readDb)
    : IRequestHandler<GetTicketByIdQuery, TicketResponse?>
{
    public async Task<TicketResponse?> Handle(GetTicketByIdQuery q, CancellationToken ct)
    {
        using var conn = readDb.Create();
        const string sql = """
            SELECT id, title, description, status, priority,
                   assignee_id AS AssigneeId,
                   reporter_id AS ReporterId,
                   sprint_id   AS SprintId,
                   due_at      AS DueAt,
                   created_at  AS CreatedAt
            FROM tickets
            WHERE id = @id
            """;
        return await conn.QueryFirstOrDefaultAsync<TicketResponse>(sql, new { id = q.Id });
    }
}

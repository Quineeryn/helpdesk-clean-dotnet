using System.Text;
using Dapper;
using MediatR;
using Helpdesk.Contracts.Tickets;
using Helpdesk.Application.Abstractions.Queries;

namespace Helpdesk.Application.Tickets.Queries.GetTickets;

public sealed class GetTicketsHandler(IReadDbConnection readDb)
    : IRequestHandler<GetTicketsQuery, IReadOnlyList<TicketResponse>>
{
    public async Task<IReadOnlyList<TicketResponse>> Handle(GetTicketsQuery q, CancellationToken ct)
    {
        using var conn = readDb.Create();

        var sb = new StringBuilder("""
            SELECT id, title, description,
                   status, priority,
                   assignee_id AS AssigneeId,
                   reporter_id AS ReporterId,
                   sprint_id AS SprintId,
                   due_at AS DueAt,
                   created_at AS CreatedAt
            FROM tickets
            """);

        var where = new List<string>();
        if (!string.IsNullOrWhiteSpace(q.Status))
            where.Add("status = @status");

        if (where.Count > 0)
            sb.Append(" WHERE ").Append(string.Join(" AND ", where));

        sb.Append(" ORDER BY created_at DESC LIMIT @take OFFSET @skip;");

        var list = await conn.QueryAsync<TicketResponse>(sb.ToString(), new
        {
            status = q.Status,
            take = q.PageSize,
            skip = (q.Page - 1) * q.PageSize
        });

        return list.ToList();
    }
}

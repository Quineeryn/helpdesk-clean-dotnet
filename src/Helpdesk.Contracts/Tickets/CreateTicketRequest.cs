using Helpdesk.Contracts.Tickets;

namespace Helpdesk.Contracts.Tickets;

public record CreateTicketRequest(
    string Title,
    string? Description,
    TicketPriorityContract Priority,
    Guid ReporterId,
    Guid? AssigneeId,
    Guid? SprintId,
    DateTimeOffset? DueAt
);

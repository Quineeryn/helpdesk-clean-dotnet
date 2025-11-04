namespace Helpdesk.Contracts.Tickets;

public record TicketResponse(
    Guid Id,
    string Title,
    string Description,
    string Status,
    string Priority,
    Guid? AssigneeId,
    Guid ReporterId,
    Guid? SprintId,
    DateTimeOffset? DueAt,
    DateTimeOffset CreatedAt
);

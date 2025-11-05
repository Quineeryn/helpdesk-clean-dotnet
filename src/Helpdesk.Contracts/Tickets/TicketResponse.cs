namespace Helpdesk.Contracts.Tickets;

// POCO class: parameterless + settable properties (Dapper-friendly)
public class TicketResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = default!;
    public string Priority { get; set; } = default!;
    public Guid? AssigneeId { get; set; }                       // nullable
    public Guid ReporterId { get; set; }
    public Guid? SprintId { get; set; }                         // nullable
    public DateTime? DueAt { get; set; }                        // gunakan DateTime? untuk sinkron dgn Npgsql default
    public DateTime CreatedAt { get; set; }                     // Npgsql default: DateTime
}

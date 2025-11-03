using Helpdesk.Core.Enums;

namespace Helpdesk.Core.Entities;

public class Ticket
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = default!;
    public string Description { get; set; } = string.Empty;
    public TicketStatus Status { get; private set; } = TicketStatus.Open;
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;
    public Guid? AssigneeId { get; set; }
    public Guid ReporterId { get; set; }
    public Guid? SprintId { get; set; }
    public DateTimeOffset? DueAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();

    public void ChangeStatus(TicketStatus newStatus)
    {
        if (Status == newStatus) return;
        Status = newStatus;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}

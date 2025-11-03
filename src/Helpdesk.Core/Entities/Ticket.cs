using Helpdesk.Core.Enums;

namespace Helpdesk.Core.Entities;

public class Ticket
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; } = default!;
    public string Description { get; private set; } = string.Empty;
    public TicketStatus Status { get; private set; } = TicketStatus.Open;
    public TicketPriority Priority { get; private set; } = TicketPriority.Medium;
    public Guid? AssigneeId { get; private set; }
    public Guid ReporterId { get; private set; }
    public Guid? SprintId { get; private set; }
    public DateTimeOffset? DueAt { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; private set; } = DateTimeOffset.UtcNow;

    // EF-friendly (interface + private setter)
    public ICollection<TicketComment> Comments { get; private set; } = new HashSet<TicketComment>();

    private Ticket() { } // EF

    public Ticket(string title, string? description, TicketPriority priority, Guid reporterId)
    {
        SetTitle(title);
        Description = (description ?? string.Empty).Trim();
        Priority = priority;
        ReporterId = reporterId;
    }

    public void SetTitle(string title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        if (title.Length > 120) throw new ArgumentOutOfRangeException(nameof(title));
        Title = title.Trim();
        Touch();
    }

    public void ChangeStatus(TicketStatus newStatus)
    {
        if (Status == newStatus) return;
        Status = newStatus;
        Touch();
    }

    public void AssignTo(Guid? assigneeId)
    {
        AssigneeId = assigneeId;
        Touch();
    }

    public void Schedule(DateTimeOffset? dueAt)
    {
        DueAt = dueAt;
        Touch();
    }

    public void AddComment(Guid authorId, string body)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(body);
        Comments.Add(new TicketComment(Id, authorId, body.Trim()));
        Touch();
    }

    private void Touch() => UpdatedAt = DateTimeOffset.UtcNow;
}

namespace Helpdesk.Core.Entities;

public class TicketComment
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid TicketId { get; private set; }
    public Guid AuthorId { get; private set; }
    public string Body { get; private set; } = default!;
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;

    private TicketComment() { } // EF
    public TicketComment(Guid ticketId, Guid authorId, string body)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(body);
        TicketId = ticketId;
        AuthorId = authorId;
        Body = body;
    }
}

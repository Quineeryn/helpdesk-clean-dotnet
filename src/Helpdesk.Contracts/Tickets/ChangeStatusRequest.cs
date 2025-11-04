using Helpdesk.Contracts.Tickets;

namespace Helpdesk.Contracts.Tickets;

public record ChangeStatusRequest(TicketStatusContract Status);

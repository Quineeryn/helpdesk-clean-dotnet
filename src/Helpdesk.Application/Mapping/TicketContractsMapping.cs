using Helpdesk.Core.Enums;
using Helpdesk.Contracts.Tickets;

namespace Helpdesk.Application.Mapping;

public static class TicketContractsMapping
{
    public static TicketPriority ToCore(this TicketPriorityContract x) => x switch
    {
        TicketPriorityContract.Low => TicketPriority.Low,
        TicketPriorityContract.Medium => TicketPriority.Medium,
        TicketPriorityContract.High => TicketPriority.High,
        _ => throw new ArgumentOutOfRangeException(nameof(x))
    };

    public static TicketStatus ToCore(this TicketStatusContract x) => x switch
    {
        TicketStatusContract.Open => TicketStatus.Open,
        TicketStatusContract.InProgress => TicketStatus.InProgress,
        TicketStatusContract.Resolved => TicketStatus.Resolved,
        _ => throw new ArgumentOutOfRangeException(nameof(x))
    };

    public static string ToContractString(this TicketStatus x) => x.ToString();
    public static string ToContractString(this TicketPriority x) => x.ToString();
}

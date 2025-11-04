namespace Helpdesk.Application.Abstractions.Services;

public interface ICurrentUser
{
    Guid? UserId { get; }
}

using System.Data;

namespace Helpdesk.Application.Abstractions.Queries;

public interface IReadDbConnection
{
    IDbConnection Create();
}

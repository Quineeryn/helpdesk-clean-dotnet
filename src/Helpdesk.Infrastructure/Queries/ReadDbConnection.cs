using System.Data;
using Helpdesk.Application.Abstractions.Queries;
using Npgsql;

namespace Helpdesk.Infrastructure.Queries;

public class ReadDbConnection(string connectionString) : IReadDbConnection
{
    public IDbConnection Create() => new NpgsqlConnection(connectionString);
}

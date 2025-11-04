using Helpdesk.Application.Abstractions.Persistence;
using Helpdesk.Application.Abstractions.Queries;
using Helpdesk.Infrastructure.Persistence;
using Helpdesk.Infrastructure.Persistence.Repositories;
using Helpdesk.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Helpdesk.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cfg)
    {
        var cs = cfg.GetConnectionString("Default")
                 ?? throw new InvalidOperationException("ConnectionStrings:Default not configured");

        services.AddDbContext<AppDbContext>(o =>
            o.UseNpgsql(cs).UseSnakeCaseNamingConvention());

        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IReadDbConnection>(_ => new ReadDbConnection(cs));

        return services;
    }
}

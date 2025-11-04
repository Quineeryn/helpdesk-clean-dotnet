using Helpdesk.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Helpdesk.Infrastructure.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // ambil dari ENV var kalau ada; fallback ke dev default
        var cs = Environment.GetEnvironmentVariable("ConnectionStrings__Default")
                 ?? "Host=localhost;Port=5432;Database=helpdesk;Username=app;Password=app";

        var builder = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(cs)
            .UseSnakeCaseNamingConvention();

        return new AppDbContext(builder.Options);
    }
}

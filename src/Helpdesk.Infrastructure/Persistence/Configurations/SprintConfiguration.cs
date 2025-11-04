using Helpdesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Infrastructure.Persistence.Configurations;

public class SprintConfiguration : IEntityTypeConfiguration<Sprint>
{
    public void Configure(EntityTypeBuilder<Sprint> e)
    {
        e.ToTable("sprints");
        e.HasKey(x => x.Id);
        e.Property(x => x.Name).HasMaxLength(80).IsRequired();
        e.HasIndex(x => new { x.StartAt, x.EndAt });
    }
}

using Helpdesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Infrastructure.Persistence.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> e)
    {
        e.ToTable("tickets");
        e.HasKey(x => x.Id);

        e.Property(x => x.Title).HasMaxLength(120).IsRequired();
        e.Property(x => x.Description).HasMaxLength(4000);

        // simpan enum sebagai string agar cocok dengan query read model kita
        e.Property(x => x.Status).HasConversion<string>().HasMaxLength(20).IsRequired();
        e.Property(x => x.Priority).HasConversion<string>().HasMaxLength(20).IsRequired();

        e.HasMany(x => x.Comments)
            .WithOne()
            .HasForeignKey(c => c.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        e.HasIndex(x => new { x.Status, x.AssigneeId });
        e.HasIndex(x => x.SprintId);
        e.HasIndex(x => x.DueAt);
    }
}

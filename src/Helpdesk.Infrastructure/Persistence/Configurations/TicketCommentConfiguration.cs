using Helpdesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Infrastructure.Persistence.Configurations;

public class TicketCommentConfiguration : IEntityTypeConfiguration<TicketComment>
{
    public void Configure(EntityTypeBuilder<TicketComment> e)
    {
        e.ToTable("ticket_comments");
        e.HasKey(x => x.Id);
        e.Property(x => x.Body).IsRequired();
        e.HasIndex(x => new { x.TicketId, x.CreatedAt });
    }
}

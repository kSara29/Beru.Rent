using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deal.Infrastructure.Persistance.Configurations;

public class DealConfiguration: IEntityTypeConfiguration<Domain.Models.Deal>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Deal> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id);
        builder.Property(l => l.CreatedAt);
        builder.Property(l => l.AdId);
        builder.Property(l => l.TenantId);
        builder.Property(l => l.Dbeg);
        builder.Property(l => l.Dend);
        builder.Property(l => l.Cost);
        builder.Property(l => l.OwnerId);
        builder.Property(l => l.DealState);
        builder.Property(l => l.Deposit);
        builder.Property(l => l.ChatId);
    }
}
using Deal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deal.Infrastructure.Persistance.Configurations;

public class ContractStoragesConfiguration: IEntityTypeConfiguration<ContractStorage>
{
    public void Configure(EntityTypeBuilder<ContractStorage> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id);
        builder.Property(l => l.CreatedAt);
        builder.Property(l => l.DealId);
        builder.Property(l => l.TemplatePath);
        builder.Property(l => l.SignedByTenanPath);
        builder.Property(l => l.SignedByOwnerPath);
    }
}
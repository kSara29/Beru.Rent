using Deal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deal.Infrastructure.Persistance.Configurations;

public class BookingConfiguration: IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id);
        builder.Property(l => l.CreatedAt);
        builder.Property(l => l.AdId);
        builder.Property(l => l.TenantId);
        builder.Property(l => l.Dbeg);
        builder.Property(l => l.Dend);
        builder.Property(l => l.Cost);
        builder.Property(l => l.BookingState);
    }
}
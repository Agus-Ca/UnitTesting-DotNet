using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnitTestingAPI.Domain.Entities;

namespace UnitTestingAPI.Infrastructure.Persistence.EFConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);

        entity.Property(e => e.Name)
            .HasMaxLength(60)
            .IsUnicode(false);

        entity.Property(e => e.Price).HasColumnType("money");
    }
}
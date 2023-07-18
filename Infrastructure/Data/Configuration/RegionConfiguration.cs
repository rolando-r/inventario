using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("Regiones");

        builder.HasKey(p => p.codRegion);
        builder.Property(p => p.codRegion)
        .ValueGeneratedNever();

        builder.Property(p => p.nombreRegion)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.Estado)
        .WithMany(e => e.Regiones)
        .HasForeignKey(i => i.codRegion);

    }
}
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("Pais");

        builder.HasKey(p => p.CodPais);
        builder.Property(p => p.CodPais)
        .ValueGeneratedNever();

        builder.Property(p => p.NombrePais)
        .IsRequired()
        .HasMaxLength(50);
    }
}
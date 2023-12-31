using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("Estados");

        builder.HasKey(p => p.codEstado);
        builder.Property(p => p.codEstado)
        .ValueGeneratedNever();

        builder.Property(p => p.nombreEstado)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.Pais)
        .WithMany(e => e.Estados)
        .HasForeignKey(i => i.CodPais);
    }
}
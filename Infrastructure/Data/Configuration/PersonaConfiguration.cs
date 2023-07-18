using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("Personas");

        builder.HasKey(p => p.IdPersona);
        builder.Property(p => p.IdPersona)
        .ValueGeneratedNever();

        builder.Property(p => p.NombrePersona)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.ApellidosPersona)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.EmailPersona)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.TipoPersona)
        .WithMany(e => e.Personas)
        .HasForeignKey(i => i.IdTipoPersona);

        builder.HasOne(p => p.Region)
        .WithMany(r => r.Personas)
        .HasForeignKey(f => f.IdRegion);
    }
}
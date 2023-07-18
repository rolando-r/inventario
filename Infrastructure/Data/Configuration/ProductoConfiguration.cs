using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Productos");

        builder.HasKey(p => p.IdProducto);
        builder.Property(p => p.IdProducto)
        .ValueGeneratedNever();

        builder.Property(p => p.NombreProducto)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Descripcion)
        .HasColumnType("text");

        builder.Property(p => p.Precio)
        .HasColumnType("double");

        builder.Property(p => p.StockMaximo)
        .HasColumnType("int");

        builder.Property(p => p.StockMinimo)
        .HasColumnType("int");
    }
}
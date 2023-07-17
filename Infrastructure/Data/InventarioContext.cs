using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class InventarioContext : DbContext
{
    public InventarioContext(DbContextOptions<InventarioContext> options) : base(options)
    {
    }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Region> Regiones { get; set; }
}
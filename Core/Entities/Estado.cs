using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class Estado
{
    [Key]
    public string ? codEstado { get; set; }
    public string ? nombreEstado { get; set; }
    public string ? CodPais { get; set; }
    public Pais ? Pais { get; set; }
    public ICollection<Region> ? Regiones { get; set; }
}
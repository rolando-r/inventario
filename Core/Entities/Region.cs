using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class Region
{
    [Key]
    public string ? codRegion { get; set; }
    public string ? nombreRegion { get; set; }
    public string ? codEstado { get; set; }
    public Estado ? Estado { get; set; }
}
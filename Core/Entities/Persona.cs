using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class Persona
{
    [Key]
    public string ? IdPersona { get; set; }
    public string ? NombrePersona { get; set; }
    public string ? ApellidosPersona { get; set; }
    public string ? EmailPersona { get; set; }
    public int IdTipoPersona { get; set; }
    public TipoPersona ? TipoPersona { get; set; }
    public string ? IdRegion { get; set; }
    public Region ? Region { get; set; }
    public ICollection<PersonaProducto>? PersonaProductos { get; set;}
}
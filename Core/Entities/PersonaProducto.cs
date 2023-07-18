namespace Core.Entities;
public class PersonaProducto
{
    public string ? IdPersona { get; set; }
    public Persona ? Persona { get; set; }
    public string ? IdProducto { get; set; }
    public Producto ? Producto { get; set; }
}

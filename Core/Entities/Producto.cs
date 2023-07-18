using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class Producto
{
    [Key]
    public string ? IdProducto { get; set; }
    public string ? NombreProducto { get; set; }
    public string ? Descripcion { get; set; }
    public double Precio { get; set; }
    public int StockMinimo { get; set; }
    public int StockMaximo { get; set; }
    public ICollection<PersonaProducto>? PersonaProductos { get; set; }
}
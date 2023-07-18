namespace Core.Interfaces;

public interface IUnitOfWork
{
    IEstado Estados { get; set; }
    IPais Paises { get; set; }
    IPersona Personas { get; set; }
    IPersonaProducto PersonasProductos { get; set; }
    IProducto Productos { get; set; }
    IRegion Regiones { get; set; }
    ITipoPersona TiposPersonas { get; set; }
    
    //metodo Post
    Task<int> SaveAsync();
}
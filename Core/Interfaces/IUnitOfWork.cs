namespace Core.Interfaces;

public interface IUnitOfWork
{
    //generamos cada una de las intefaces que se tiene desarrolladas 
    IEstado Estados { get; set; }
    IPais Paises { get; set; }
    IPersona Personas { get; set; }
    IProducto Productos { get; set; }
    IRegion Regiones { get; set; }
    ITipoPersona TiposPersonas { get; set; }
    
    //metodo Post
    Task<int> SaveAsync();
}

namespace Core.Interfaces;

public interface IUnitOfWork
{
    IPais Paises { get; set; }
    ITipoPersona TiposPersonas { get; set; }
    
    //metodo Post
    Task<int> SaveAsync();
}
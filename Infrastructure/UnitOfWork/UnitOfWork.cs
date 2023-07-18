using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    //variable context
    private readonly InventarioContext _context;

    //generamos variables de cada repositorio creado
    private PaisRepository ? _paises;
    private TipoPersonaRepository ? _tiposPersonas;

    //generamos el constructor de la variable context
    public UnitOfWork(InventarioContext context)
    {
        _context = context;
    }

    //generamos el constructor de las varibales del repository

    //Paises
    public IPais Paises
    {
        get
        {
            if (_paises == null) {
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }

        set 
        {
            if (_paises == null) {
                _paises = new PaisRepository(_context);
            }
        }
    }

    //TiposPersonas
    public ITipoPersona TiposPersonas
    {
        get
        {
            if (_tiposPersonas == null) {
                _tiposPersonas = new TipoPersonaRepository(_context);
            }
            return _tiposPersonas;
        }

        set 
        {
            if (_tiposPersonas == null) {
                _tiposPersonas = new TipoPersonaRepository(_context);
            }
        }
    }

    public void Dispose()
    {
        _context.Dispose(); //destruir el contexto si no se esta Utilizando, liberar memoria 
    }
    
    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }

    
}
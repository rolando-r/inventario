using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TipoPersonaRepository : ITipoPersona
{
    //variable de contexto
    protected readonly InventarioContext _context;
    //constructor
    public TipoPersonaRepository(InventarioContext context)
    {
        _context = context;
    }

    public void Add(TipoPersona entity)
    {
        _context.Set<TipoPersona>().Add(entity);
    }

    public void AddRange(IEnumerable<TipoPersona> entities)
    {
        _context.Set<TipoPersona>().AddRange(entities);
    }

    public IEnumerable<TipoPersona> Find(Expression<Func<TipoPersona, bool>> expression)
    {
        return _context.Set<TipoPersona>().Where(expression);
    }

    public async Task<IEnumerable<TipoPersona>> GetAllAsync()
    {
        return await _context.Set<TipoPersona>().ToListAsync();
    }

    public Task<TipoPersona> GetByIdAsycn(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<TipoPersona> GetByIdAsync(string id)
    {
        return await _context.Set<TipoPersona>().FindAsync(id);
    }

    public void Remove(TipoPersona entity)
    {
        _context.Set<TipoPersona>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TipoPersona> entities)
    {
        _context.Set<TipoPersona>().RemoveRange(entities);
    }

    public void Update(TipoPersona entity)
    {
        _context.Set<TipoPersona>().Update(entity);
    }
}
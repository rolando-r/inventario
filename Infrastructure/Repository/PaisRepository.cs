
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PaisRepository : IPais
{
    //variable de contexto
    protected readonly InventarioContext _context;
    //constructor
    public PaisRepository(InventarioContext context)
    {
        _context = context;
    }

    public void Add(Pais entity)
    {
        _context.Set<Pais>().Add(entity);
    }

    public void AddRange(IEnumerable<Pais> entities)
    {
        _context.Set<Pais>().AddRange(entities);
    }

    public IEnumerable<Pais> Find(Expression<Func<Pais, bool>> expression)
    {
        return _context.Set<Pais>().Where(expression);
    }

    public async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.Set<Pais>().ToListAsync();
    }

    public Task<Pais> GetByIdAsycn(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Pais> GetByIdAsync(string id)
    {
        return await _context.Set<Pais>().FindAsync(id);
    }

    public void Remove(Pais entity)
    {
        _context.Set<Pais>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Pais> entities)
    {
        _context.Set<Pais>().RemoveRange(entities);
    }

    public void Update(Pais entity)
    {
        _context.Set<Pais>().Update(entity);
    }
}

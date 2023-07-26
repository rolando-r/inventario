using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PersonaRepository : IPersona
{
    //variable de contexto
    protected readonly InventarioContext _context;
    //constructor
    public PersonaRepository(InventarioContext context)
    {
        _context = context;
    }

    public void Add(Persona entity)
    {
        _context.Set<Persona>().Add(entity);
    }

    public void AddRange(IEnumerable<Persona> entities)
    {
        _context.Set<Persona>().AddRange(entities);
    }

    public IEnumerable<Persona> Find(Expression<Func<Persona, bool>> expression)
    {
        return _context.Set<Persona>().Where(expression);
    }

    public async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Set<Persona>().ToListAsync();
    }

    public Task<Persona> GetByIdAsycn(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Persona> GetByIdAsync(string id)
    {
        return await _context.Set<Persona>().FindAsync(id);
    }

    public void Remove(Persona entity)
    {
        _context.Set<Persona>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Persona> entities)
    {
        _context.Set<Persona>().RemoveRange(entities);
    }

    public void Update(Persona entity)
    {
        _context.Set<Persona>().Update(entity);
    }
}
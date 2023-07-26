using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ProductoRepository : IProducto
{
    //variable de contexto
    protected readonly InventarioContext _context;
    //constructor
    public ProductoRepository(InventarioContext context)
    {
        _context = context;
    }

    public void Add(Producto entity)
    {
        _context.Set<Producto>().Add(entity);
    }

    public void AddRange(IEnumerable<Producto> entities)
    {
        _context.Set<Producto>().AddRange(entities);
    }

    public IEnumerable<Producto> Find(Expression<Func<Producto, bool>> expression)
    {
        return _context.Set<Producto>().Where(expression);
    }

    public async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Set<Producto>().ToListAsync();
    }

    public Task<Producto> GetByIdAsycn(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Producto> GetByIdAsync(string id)
    {
        return await _context.Set<Producto>().FindAsync(id);
    }

    public void Remove(Producto entity)
    {
        _context.Set<Producto>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Producto> entities)
    {
        _context.Set<Producto>().RemoveRange(entities);
    }

    public void Update(Producto entity)
    {
        _context.Set<Producto>().Update(entity);
    }
}
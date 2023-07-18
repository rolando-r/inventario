using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;
public interface IPais
{
    Task<Pais> GetByIdAsync(string id);
    Task<IEnumerable<Pais>> GetAllAsync();
    IEnumerable<Pais> Find(Expression<Func<ParameterizedThreadStart,bool>> expression);
    void Add(Pais entity);
    void AddRange(IEnumerable<Pais> entities);
    void Remove(Pais entity);
    void RemoveRange(IEnumerable<Pais> entities);
    void Update(Pais entity);
}
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;
    public interface IPersonaProducto
    {
        Task<PersonaProducto> GetByIdAsync(string id);
        Task<IEnumerable<PersonaProducto>> GetAllAsync();
        IEnumerable<PersonaProducto> Find(Expression<Func<PersonaProducto,bool>> expression);
        void Add(PersonaProducto entity);
        void AddRange(IEnumerable<PersonaProducto> entities);
        void Remove(PersonaProducto entity);
        void RemoveRange(IEnumerable<PersonaProducto> entities);
        void Update(PersonaProducto entity);
    }
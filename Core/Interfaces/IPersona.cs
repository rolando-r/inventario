using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;
    public interface IPersona
    {
        Task<Persona> GetByIdAsync(string id);
        Task<IEnumerable<Persona>> GetAllAsync();
        IEnumerable<Persona> Find(Expression<Func<Persona,bool>> expression);
        void Add(Persona entity);
        void AddRange(IEnumerable<Persona> entities);
        void Remove(Persona entity);
        void RemoveRange(IEnumerable<Persona> entities);
        void Update(Persona entity);
    }
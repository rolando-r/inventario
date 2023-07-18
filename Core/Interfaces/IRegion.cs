using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;
    public interface IRegion
    {
        Task<Region> GetByIdAsync(string id);
        Task<IEnumerable<Region>> GetAllAsync();
        IEnumerable<Region> Find(Expression<Func<Region,bool>> expression);
        void Add(Region entity);
        void AddRange(IEnumerable<Region> entities);
        void Remove(Region entity);
        void RemoveRange(IEnumerable<Region> entities);
        void Update(Region entity);
    }
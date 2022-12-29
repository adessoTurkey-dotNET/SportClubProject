using VolleyballClubProject.Core.Entities;

namespace VolleyballClubProject.Core.Common
{
    public interface IBaseInterface<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T entity);
        void Remove(int id);
        void Update(T entity);
    }
}

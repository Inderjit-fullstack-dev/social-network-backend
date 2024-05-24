using System.Linq.Expressions;

namespace SocialNetwork.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> ListAsync();
        public Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression);
        public Task<T?> GetAsync(int id);
        public Task<T?> GetAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}

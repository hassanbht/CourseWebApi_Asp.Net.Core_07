using CourseWebApi.Model.Framework;
using System.Linq.Expressions;

namespace CourseWebApi.Model.Repositories
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        Task<bool> Add(T entity);
        Task<bool> AddRange(ICollection<T> list);
        Task<bool> AddRangeAsync(ICollection<T> list, CancellationToken cancellationToken);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> AddAsync(T entity, CancellationToken cancellationToken);
        Task<T?> GetById(int id, params Expression<Func<T, object>>[]? including);
        Task<ICollection<T>> GetAll(params Expression<Func<T, object>>[]? including);
        Task<ICollection<T>> Find(Expression<Func<T, bool>> expression);
    }


}

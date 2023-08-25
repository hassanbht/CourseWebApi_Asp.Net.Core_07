
using CourseStore.Model.Framework;
using System.Linq.Expressions;

namespace CourseWebApi.Model.Repositories
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task<T> GetById(int id);
        Task<ICollection<T>> GetAll();
        Task<ICollection<T>> Find(Expression<Func<T, bool>> expression);
    }


}

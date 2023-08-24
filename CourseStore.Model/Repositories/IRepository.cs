
using CourseStore.Model.Framework;
using System.Linq.Expressions;

namespace CourseWebApi.Model.Repositories
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }


}

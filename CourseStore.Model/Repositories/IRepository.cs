using CourseStore.Model.Framework;

namespace CourseWebApi.Model.Repositories
{
    public interface IRepository<in T> : IDisposable where T : BaseEntity
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void Add(T entity);
        void Update(T entity);
        Task AddAsync(T entity, CancellationToken cancellationToken);

    }
}

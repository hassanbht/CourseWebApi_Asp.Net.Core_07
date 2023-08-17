using CourseStore.Model.Framework;

namespace CourseWebApi.DAL.Repositories
{
    public interface IRepository<in T> : IDisposable where T : BaseEntity
    {
        int SaveChanges();
        void Add(T entity);
        void Update(T entity);

    }
}

using CourseStore.Model.Framework;

namespace CourseWebApi.BLL.Infra
{
    public interface IRepository<in T> : IDisposable where T : BaseEntity
    {
        int SaveChanges();
        void Add(T entity);
        void Update(T entity);
    }
}

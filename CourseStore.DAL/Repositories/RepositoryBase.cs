using CourseStore.DAL.Contexts;
using CourseStore.Model.Framework;
using CourseWebApi.BLL.Infra;

namespace CourseWebApi.DAL.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CourseStoreDbContext courseStoreDb;

        public RepositoryBase(CourseStoreDbContext courseStoreDb)
        {
            this.courseStoreDb = courseStoreDb;
        }

        public int SaveChanges() => courseStoreDb.SaveChangesAsync().Result;

        public void Add(T entity) => courseStoreDb.Add(entity);
        public void Update(T entity) => courseStoreDb.Update(entity);

        public void Dispose()
        {
            courseStoreDb.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

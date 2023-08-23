using CourseStore.DAL.Contexts;
using CourseStore.Model.Framework;
using CourseWebApi.Model.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CourseWebApi.DAL.Repositories
{
    public class RepositoryDbContext<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CourseStoreDbContext courseStoreDb;
        private DbSet<T> _entities;
        public RepositoryDbContext(CourseStoreDbContext courseStoreDb)
        {
            this.courseStoreDb = courseStoreDb;
            this._entities = courseStoreDb.Set<T>();
        }

        public void Add(T entity) => courseStoreDb.Add(entity);
        public async Task AddAsync(T entity, CancellationToken cancellationToken) => await courseStoreDb.AddAsync(entity, cancellationToken);

        public void Update(T entity) => courseStoreDb.Update(entity);
        public int SaveChanges() => courseStoreDb.SaveChanges();
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) => await courseStoreDb.SaveChangesAsync(cancellationToken);

        public void Dispose()
        {
            courseStoreDb.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}

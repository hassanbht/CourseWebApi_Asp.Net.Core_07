using CourseStore.DAL.Contexts;
using CourseStore.Model.Framework;
using CourseWebApi.Model.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            courseStoreDb.SaveChanges();
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken) {

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await _entities.AddAsync(entity);
            await courseStoreDb.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Update(entity);
            courseStoreDb.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            courseStoreDb.SaveChanges();
        }


        public void Dispose()
        {
            courseStoreDb.Dispose();
            GC.SuppressFinalize(this);
        }

        public T GetById(int id)
        {
          return _entities.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _entities.Where(expression);
        }
    }
}

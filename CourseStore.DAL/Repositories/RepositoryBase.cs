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

        public async Task Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            await courseStoreDb.SaveChangesAsync();
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await _entities.AddAsync(entity);
            await courseStoreDb.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Update(entity);
            await courseStoreDb.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            await courseStoreDb.SaveChangesAsync();
        }


        public Task<T> GetById(int id)
        {
            return _entities.FirstOrDefaultAsync(x => x.Id == id)!;
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<ICollection<T>> Find(Expression<Func<T, bool>> expression)
        {
            return  await _entities.Where(expression).ToListAsync();
        }

        public void Dispose()
        {
            courseStoreDb.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

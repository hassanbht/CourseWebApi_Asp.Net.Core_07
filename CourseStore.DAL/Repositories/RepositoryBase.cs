using CourseStore.DAL.Contexts;
using CourseStore.Model.Framework;
using CourseWebApi.Model.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CourseWebApi.DAL.Repositories
{
    public class RepositoryDbContext<T> : IRepository<T> where T : BaseEntity 
    {
        private readonly CourseStoreDbContext _courseStoreDb;
        private DbSet<T> _entities;
        public RepositoryDbContext(CourseStoreDbContext courseStoreDb)
        {
            this._courseStoreDb = courseStoreDb;
            this._entities = courseStoreDb.Set<T>();
        }

        public  async Task<bool> Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);

            return await _courseStoreDb.SaveChangesAsync()>0;
            
        }
        public async Task<bool> AddAsync(T entity, CancellationToken cancellationToken)
        {

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await _entities.AddAsync(entity);
            return await _courseStoreDb.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Update(entity);
          return  await _courseStoreDb.SaveChangesAsync()>0;
        }

        public async Task<bool> Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            return await _courseStoreDb.SaveChangesAsync() > 0;
        }

        public async Task<T?> GetById(int id, params Expression<Func<T, object>>[]? including)
        {
            var query = _entities.AsQueryable();
            if (including != null)
                including.ToList().ForEach(include =>
                {
                    if (include != null)
                        query = query.Include(include);
                });
            return await query.FirstOrDefaultAsync(x => x.Id == id);
           
        }

        public async Task<ICollection<T>> GetAll(params Expression<Func<T, object>>[]? including)
        {
            var query = _entities.AsQueryable();
            if (including != null)
                including.ToList().ForEach(include =>
                {
                    if (include != null)
                        query = query.Include(include);
                });
            return await query.ToListAsync();
        }

        public async Task<ICollection<T>> Find(Expression<Func<T, bool>> expression)
        {
            return  await _entities.Where(expression).ToListAsync();
        }

        public void Dispose()
        {
            _courseStoreDb.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

using CourseStore.Model.Framework;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CourseWebApi.DAL.Repositories
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

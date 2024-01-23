using System.Collections;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq.Expressions;

namespace CourseWebApi.DAL.Repositories
{
    //public class DbSetRepository<T> : IDbSet<T> where T : class
    //{
    //    private readonly DbSet<T> _set;
    //    public DbSetRepository(DbSet<T> set) => _set = set;

    //    public Type ElementType => ((IQueryable<T>)_set).ElementType;
    //    public Expression Expression => ((IQueryable<T>)_set).Expression;
    //    public IQueryProvider Provider => ((IQueryable<T>)_set).Provider;

    //    public ObservableCollection<T> Local => throw new NotImplementedException();

    //    public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)_set).GetEnumerator();
    //    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)_set).GetEnumerator();

    //    public T Add(T entity)
    //    {
    //        return _set.Add(entity);
    //    }

    //    public T Remove(T entity)
    //    {
    //        return _set.Remove(entity);
    //    }

    //    public T Attach(T entity)
    //    {
    //        return _set.Attach(entity);
    //    }

    //    public T Create()
    //    {
    //        return (_set.Create());
    //    }

    //    TDerivedEntity IDbSet<T>.Create<TDerivedEntity>()
    //    {
    //        return (TDerivedEntity)_set.Create();
    //    }

    //    T IDbSet<T>.Find(params object[] keyValues)
    //    {
    //        return _set.Find(keyValues);
    //    }
    //}

}

using Microsoft.EntityFrameworkCore.Query;
using MovieTracker.DBContexts;
using MovieTracker.Models;
using System.Linq.Expressions;
using System.Security.Principal;

namespace MovieTracker.Repository
{
    public interface IGenericRepository<T, TContext>
        where T : class, IEntity
        where TContext : IDatabaseContext
    {
        ValueTask<IEnumerable<T>> GetAllAsync();
        ValueTask<T> FindAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        Task<T> FindAsync(Expression<Func<T, bool>> uniqueKeyExpression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        ValueTask<IQueryable<T>> GetQueryableAsyncByQuery(Func<IQueryable<T>, IQueryable<T>> queryFunction = null);

        ValueTask<IEnumerable<T>> GetAsyncByQuery(Func<IQueryable<T>, IQueryable<T>> queryFunction = null);

        ValueTask<T> InsertAsync(T entity);

        ValueTask<T> UpdateAsync(int id, T entity);

        ValueTask DeleteAsync(int id);

        ValueTask<bool> Exists(Func<IQueryable<T>, IQueryable<T>> queryFunction = null);

        Task SaveAsync();
    }
}

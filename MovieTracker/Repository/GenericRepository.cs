using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using MovieTracker.DBContexts;
using MovieTracker.Models;
using System.Linq.Expressions;

namespace MovieTracker.Repository
{
    public class GenericRepository<T, TContext> : IGenericRepository<T, TContext>
         where T : class, IEntity
        where TContext : IDatabaseContext
    {
        private readonly TContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepository(TContext context)
        {
            _context = context;
            _entities = context.Set<T>();
           
        }

        public async ValueTask<IEnumerable<T>> GetAllAsync()
        {
            return await ValueTask.FromResult(_entities.ToList());
        }

        public async ValueTask<T> FindAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            if (includes != null)
            {
                return await includes(_entities).FirstOrDefaultAsync(x => x.Id == id);
            }

            return await _entities.FindAsync(id);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> uniqueKeyExpression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            if (includes != null)
            {
                return await includes(_entities).SingleOrDefaultAsync(uniqueKeyExpression);
            }

            return await _entities.SingleOrDefaultAsync(uniqueKeyExpression);
        }

        public async ValueTask<IQueryable<T>> GetQueryableAsyncByQuery(Func<IQueryable<T>, IQueryable<T>> queryFunction = null)
        {
            IQueryable<T> queriedEntities = _entities;

            if (queryFunction != null)
            {
                queriedEntities = queryFunction(queriedEntities);
            }

            //T implements ISortable
            if (typeof(ISortable).IsAssignableFrom(typeof(T)))
            {
                IQueryable<ISortable> sortables = (IQueryable<ISortable>)queriedEntities;

                queriedEntities = sortables.OrderBy(sortable => sortable.SortIndex).Cast<T>();
            }

            return await ValueTask.FromResult(queriedEntities);
        }

        public async ValueTask<IEnumerable<T>> GetAsyncByQuery(Func<IQueryable<T>, IQueryable<T>> queryFunction = null)
        {
            var queriedEntities = await GetQueryableAsyncByQuery(queryFunction);

            return await ValueTask.FromResult(queriedEntities.ToList());
        }

        public async ValueTask<T> InsertAsync(T entity)
        {
            var insertedEntity = await _entities.AddAsync(entity);

            var insertedCollections = insertedEntity.Collections.Where(x => x.IsModified);

            await _context.SaveAsync();

            return insertedEntity.Entity;
        }

        public async ValueTask<T> UpdateAsync(int id, T entity)
        {
            var originalEntity = await _entities.FindAsync(id);

            var entityToUpdate = _context.Entry(originalEntity);
            entityToUpdate.CurrentValues.SetValues(entity);


            await _context.SaveAsync();

            return entityToUpdate.Entity;
        }

        public async ValueTask DeleteAsync(int id)
        {
            T entity = await FindAsync(id);
            _entities.Remove(entity);

            await _context.SaveAsync();
        }

        public async ValueTask<bool> Exists(Func<IQueryable<T>, IQueryable<T>> queryFunction = null)
        {
            IQueryable<T> queriedEntities = _entities;

            if (queryFunction != null)
            {
                queriedEntities = queryFunction(queriedEntities);
            }

            return await queriedEntities.AnyAsync();
        }

        public Task SaveAsync()
        {
            return _context.SaveAsync();
        }
    }
}

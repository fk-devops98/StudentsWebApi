using Students.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Students.Domain.Ports.Base;
using System.Linq.Expressions;

namespace Students.Infrastructure.Adapters.Base
{
    public class BaseRepository<E> : IBaseRepository<E> where E : Students.Domain.Entities.Base.DomainEntity
    {
        protected readonly PersistenceContext _context;

        public BaseRepository(PersistenceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<E> AddAsync(E entity)
        {
            try
            {
                _ = entity ?? throw new ArgumentNullException(nameof(entity), "Entity can not be null");
                _context.Set<E>().Add(entity);
                await CommitAsync();
                return entity;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(E entity)
        {
            if (entity != null)
            {
                _context.Set<E>().Remove(entity);
                await CommitAsync().ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>>? filter = null, Func<IQueryable<E>, IOrderedQueryable<E>>? orderBy = null, string includeStringProperties = "", bool isTracking = false)
        {
            IQueryable<E> query = _context.Set<E>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeStringProperties))
            {
                foreach (var includeProperty in includeStringProperties.Split
                    (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync().ConfigureAwait(false);
            }

            return !isTracking ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
        }

        public async Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>>? filter = null, Func<IQueryable<E>, IOrderedQueryable<E>>? orderBy = null, bool isTracking = false, params Expression<Func<E, object>>[] includeObjectProperties)
        {
            IQueryable<E> query = _context.Set<E>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeObjectProperties != null)
            {
                foreach (Expression<Func<E, object>> include in includeObjectProperties)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return !isTracking ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
        }

        public async Task<E> GetByIdAsync(object id)
        {
            return await _context.Set<E>().FindAsync(id);
        }

        public async Task<E> UpdateAsync(E entity)
        {
            if (entity != null)
            {
                _context.Set<E>().Update(entity);
                await CommitAsync();
                return entity;
            }
            return null;
        }

        public async Task CommitAsync()
        {
            _context.ChangeTracker.DetectChanges();
            await _context.CommitAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Common.Interfaces;

namespace TodoApp.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Generic EF Core repository implementation.
    /// Assumes entities use Guid primary keys for GetByIdAsync; adapt if your PKs differ.
    /// </summary>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            // FindAsync returns the tracked entity; we return as-is to allow callers to update if desired.
            var found = await _dbSet.FindAsync(new object[] { id }, cancellationToken).ConfigureAwait(false);
            return found as T;
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _dbSet.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Remove(entity);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
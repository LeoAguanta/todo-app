using Microsoft.EntityFrameworkCore;
using todo_app.Domain.Entities;
using TodoApp.Application.Interfaces.Repositories;

namespace TodoApp.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Concrete repository for Todo-specific queries.
    /// Inherits generic Repository<T> behavior.
    /// </summary>
    public class TodoRepository : Repository<TodoItem>, ITodoRepository
    {
        public TodoRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TodoItem>> GetActiveTodosAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsNoTracking()
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<TodoItem>> GetOverdueTodosAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;
            return await _dbSet
                .AsNoTracking()
                .Where(t => !t.Done)
                .OrderBy(t => t.Created)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<TodoItem>> SearchByTitleAsync(string term, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return Array.Empty<TodoItem>();
            }

            term = term.Trim();
            return await _dbSet
                .AsNoTracking()
                .Where(t => EF.Functions.Like(t.Title, $"%{term}%"))
                .OrderBy(t => t.Created)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}

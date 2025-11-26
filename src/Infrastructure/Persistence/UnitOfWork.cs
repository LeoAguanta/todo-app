using Microsoft.EntityFrameworkCore;
using todo_app.Domain.Entities;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Application.Interfaces.Repositories;
using TodoApp.Domain.Common.Interfaces;
using TodoApp.Infrastructure.Persistence.Repositories;

namespace TodoApp.Infrastructure.Persistence
{
    /// <summary>
    /// UnitOfWork implementation that exposes domain-specific repositories and commits through DbContext.
    /// Includes both ITodoRepository and a generic IRepository<TodoList> to demonstrate mixed usage.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Todos = new TodoRepository(_context);
            TodoLists = new Repository<TodoList>(_context);
        }

        public ITodoRepository Todos { get; }

        public IRepository<TodoList> TodoLists { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

using todo_app.Infrastructure.Data;
using TodoApp.Application.Common.Interfaces;

namespace TodoApp.Infrastructure.Persistence
{
    /// <summary>
    /// UnitOfWork implementation that exposes domain-specific repositories and commits through DbContext.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            //Todos = new Repositories.TodoRepository(_context);
        }

        //public ITodoRepository Todos { get; }

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

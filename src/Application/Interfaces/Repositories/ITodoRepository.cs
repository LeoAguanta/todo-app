using todo_app.Domain.Entities;
using TodoApp.Domain.Common.Interfaces;

namespace TodoApp.Application.Interfaces.Repositories
{
    /// <summary>
    /// Domain-specific repository for Todo entity.
    /// Inherits generic IRepository methods (add/update/delete/list/etc).
    /// </summary>
    public interface ITodoRepository : IRepository<TodoItem>
    {
        Task<IEnumerable<TodoItem>> GetActiveTodosAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoItem>> GetOverdueTodosAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoItem>> SearchByTitleAsync(string term, CancellationToken cancellationToken = default);
    }
}

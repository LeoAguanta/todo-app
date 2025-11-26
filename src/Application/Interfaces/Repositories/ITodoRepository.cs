using todo_app.Domain.Entities;
using TodoApp.Domain.Common.Interfaces;

namespace TodoApp.Application.Interfaces.Repositories
{
    /// <summary>
    /// Domain-specific repository for Todo entity.
    /// Inherits generic IRepository methods (add/update/delete/list/etc).
    /// </summary>
    public interface ITodoRepository : IRepository<TodoList>
    {
        Task<IEnumerable<TodoList>> GetActiveTodosAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoList>> GetOverdueTodosAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoList>> SearchByTitleAsync(string term, CancellationToken cancellationToken = default);
    }
}

using todo_app.Domain.Entities;
using TodoApp.Application.Interfaces.Repositories;
using TodoApp.Domain.Common.Interfaces;

namespace TodoApp.Application.Common.Interfaces
{
    /// <summary>
    /// Unit of Work abstraction to coordinate saving across repositories.
    /// Exposes domain-specific repositories and/or generic repositories as needed.
    /// </summary>
    public interface IUnitOfWork
    {
        ITodoRepository Todos { get; }

        // Expose generic repository for TodoList so application logic can use generic repo when
        // no specialized repository is required.
        IRepository<TodoList> TodoLists { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

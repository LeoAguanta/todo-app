namespace TodoApp.Application.Common.Interfaces
{
    /// <summary>
    /// Unit of Work abstraction to coordinate saving across repositories.
    /// Keeps higher layers decoupled from DbContext.
    /// </summary>
    public interface IUnitOfWork
    {
        //ITodoRepository Todos { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

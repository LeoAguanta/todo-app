namespace TodoApp.Domain.Common.Interfaces
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Read/Write repository contract. For transactional/save behavior you can replace this pattern
    /// with an explicit UnitOfWork if you prefer.
    /// </summary>
    public interface IRepository<T> : IReadRepository<T> where T : class
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);

        /// <summary>
        /// Convenience: save changes (commits) for implementations that have direct access to DbContext.
        /// If you use UnitOfWork pattern, keep SaveChanges here out of the interface.
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
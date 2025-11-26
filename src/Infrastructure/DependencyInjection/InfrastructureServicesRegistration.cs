using System;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Application.Interfaces.Repositories;
using TodoApp.Infrastructure.Persistence;
using TodoApp.Infrastructure.Persistence.Repositories;
using TodoApp.Domain.Common.Interfaces;

namespace TodoApp.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Registers generic repositories, TodoRepository and UnitOfWork.
    /// Call this after registering your DbContext in the composition root.
    /// </summary>
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Generic repository registration: IRepository<T> -> Repository<T>
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(Repository<>));

            // Domain-specific repository and unit of work
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
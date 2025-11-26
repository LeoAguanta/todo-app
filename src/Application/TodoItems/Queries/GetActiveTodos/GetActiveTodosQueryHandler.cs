using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoApp.Application.TodoItems.Dto;
using TodoApp.Application.Common.Interfaces;

namespace TodoApp.Application.TodoItems.Queries
{
    public class GetActiveTodosQueryHandler : IRequestHandler<GetActiveTodosQuery, IEnumerable<TodoItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetActiveTodosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TodoItemDto>> Handle(GetActiveTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = await _unitOfWork.Todos.GetActiveTodosAsync(cancellationToken).ConfigureAwait(false);

            // Map domain entities to DTOs (simple projection)
            return todos.Select(t => new TodoItemDto
            {
                Id = t.Id,
                Title = t.Title,
                IsComplete = t.IsComplete,
                DueDate = t.DueDate,
                CreatedAt = t.CreatedAt
            }).ToList();
        }
    }
}
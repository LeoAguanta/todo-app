using todo_app.Domain.Entities;
using TodoApp.Application.Common.Interfaces;

namespace TodoApp.Application.TodoItems.Commands
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTodoItemCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todo = new TodoItem
            {
                Title = request.Title,
                Created = DateTime.UtcNow
            };

            await _unitOfWork.Todos.AddAsync(todo, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return todo.Id;
        }
    }
}

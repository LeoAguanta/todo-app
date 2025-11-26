using todo_app.Domain.Entities;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Domain.Common.Interfaces;

namespace TodoApp.Application.TodoLists.Commands
{
    /// <summary>
    /// Example handler demonstrating use of the generic repository for TodoList plus UnitOfWork to commit.
    /// Uses IRepository<TodoList> (generic) rather than a domain-specific ITodoListRepository.
    /// </summary>
    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
    {
        private readonly IRepository<TodoList> _todoListRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTodoListCommandHandler(IRepository<TodoList> todoListRepository, IUnitOfWork unitOfWork)
        {
            _todoListRepository = todoListRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var todoList = new TodoList
            {
                Title = request.Title,
                Created = DateTime.UtcNow
            };

            await _todoListRepository.AddAsync(todoList, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return todoList.Id;
        }
    }
}

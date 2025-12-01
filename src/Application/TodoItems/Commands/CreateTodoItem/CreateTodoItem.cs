using todo_app.Domain.Entities;
using todo_app.Domain.Events;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Domain.Common.Interfaces;

namespace todo_app.Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand : IRequest<int>
{
    public int ListId { get; init; }

    public string? Title { get; init; }
}

public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
{
    private readonly IRepository<TodoItem> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTodoItemCommandHandler(IRepository<TodoItem> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            ListId = request.ListId,
            Title = request.Title,
            Done = false
        };

        entity.AddDomainEvent(new TodoItemCreatedEvent(entity));


        await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return entity.Id;
    }
}

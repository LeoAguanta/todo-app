namespace TodoApp.Application.TodoItems.Commands
{
    /// <summary>
    /// Creates a new Todo item.
    /// Returns the created entity Id.
    /// </summary>
    public class CreateTodoItemCommand : IRequest<int>
    {
        public string Title { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
    }
}

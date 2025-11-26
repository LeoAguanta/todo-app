namespace TodoApp.Application.TodoLists.Commands
{
    public class CreateTodoListCommand : IRequest<int>
    {
        public string Title { get; set; } = string.Empty;
    }
}

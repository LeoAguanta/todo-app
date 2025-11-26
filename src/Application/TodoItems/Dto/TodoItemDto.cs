namespace TodoApp.Application.TodoItems.Dto
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}

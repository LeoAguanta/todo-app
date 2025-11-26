using System;

namespace TodoApp.Application.TodoLists.Dto
{
    public class TodoListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
using System;
using MediatR;

namespace TodoApp.Application.TodoLists.Commands
{
    public class CreateTodoListCommand : IRequest<Guid>
    {
        public string Title { get; set; } = string.Empty;
    }
}
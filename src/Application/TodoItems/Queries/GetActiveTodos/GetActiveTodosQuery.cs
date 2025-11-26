using System.Collections.Generic;
using MediatR;
using TodoApp.Application.TodoItems.Dto;

namespace TodoApp.Application.TodoItems.Queries
{
    public class GetActiveTodosQuery : IRequest<IEnumerable<TodoItemDto>>
    {
    }
}
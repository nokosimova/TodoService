using System.Collections.Generic;
using MediatR;
using TodoService.Application.DTO;

namespace TodoService.Application.TodoItems.Queries
{
    public class GetAllTodoItemsQuery : IRequest<IEnumerable<TodoItemDTO>>
    {
    }
}
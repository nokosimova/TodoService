using System.Collections.Generic;
using MediatR;
using TodoService.Domain.Entities;

namespace TodoService.Application.TodoItems.Queries
{
    public class GetAllTodoItemsQuery : IRequest<IEnumerable<TodoItem>>
    {
    }
}
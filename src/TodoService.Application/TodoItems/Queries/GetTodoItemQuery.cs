using MediatR;
using TodoService.Application.DTO;
using TodoService.Domain.Entities;

namespace TodoService.Application.TodoItems.Queries
{
    public class GetTodoItemQuery : IRequest<TodoItem>
    {
        public long Id { get; set; }
    }
}
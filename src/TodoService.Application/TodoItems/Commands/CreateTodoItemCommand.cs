using MediatR;
using TodoService.Domain.Entities;

namespace TodoService.Application.TodoItems.Commands
{
    public class CreateTodoItemCommand : IRequest<TodoItem>
    {
        public TodoItem Item { get; set; }
    }
}
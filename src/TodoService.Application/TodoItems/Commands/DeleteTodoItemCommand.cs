using MediatR;
using TodoService.Domain.Entities;

namespace TodoService.Application.TodoItems.Commands
{
    public class DeleteTodoItemCommand : IRequest
    {
        public TodoItem Item { get; set; }
    }
}
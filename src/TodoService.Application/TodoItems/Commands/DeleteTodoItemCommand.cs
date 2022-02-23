using MediatR;
using TodoService.Application.DTO;

namespace TodoService.Application.TodoItems.Commands
{
    public class DeleteTodoItemCommand : IRequest
    {
        public TodoItemDTO Item { get; set; }
    }
}
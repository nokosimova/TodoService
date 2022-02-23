using MediatR;
using TodoService.Application.DTO;

namespace TodoService.Application.TodoItems.Commands
{
    public class CreateTodoItemCommand : IRequest<TodoItemDTO>
    {
        public TodoItemDTO Item { get; set; }
    }
}
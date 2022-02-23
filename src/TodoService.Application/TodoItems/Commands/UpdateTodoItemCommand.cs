using MediatR;
using TodoService.Application.DTO;

namespace TodoService.Application.TodoItems.Commands
{
    public class UpdateTodoItemCommand: IRequest<TodoItemDTO>
    {
        public TodoItemDTO Item { get; set; }
    }
}
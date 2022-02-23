using MediatR;
using TodoService.Application.DTO;
using TodoService.Domain.Entities;

namespace TodoService.Application.TodoItems.Commands
{
    public class UpdateTodoItemCommand: IRequest<Unit>
    {
        public TodoItemDTO UpdatedItem { get; set; }
        public TodoItem Item { get; set; }
    }
}
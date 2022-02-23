using MediatR;
using TodoService.Application.DTO;

namespace TodoService.Application.TodoItems.Queries
{
    public class GetTodoItemQuery : IRequest<TodoItemDTO>
    {
        public long id { get; set; }
    }
}
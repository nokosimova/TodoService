using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoService.Application.DTO;
using TodoService.Application.TodoItems.Commands;
using TodoService.Application.TodoItems.Queries;
using TodoService.Domain.Entities;
using TodoService.Infrastructure.Repository;

namespace TodoService.Application.TodoItems.Handlers
{
    public class GetTodoItemQueryHandler : IRequestHandler<GetTodoItemQuery, TodoItemDTO>
    {
    private readonly IRepository<TodoItem> _repository;

    public GetTodoItemQueryHandler(IRepository<TodoItem> repository)
    {
        _repository = repository;
    }

    public Task<TodoItemDTO> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
    }
}
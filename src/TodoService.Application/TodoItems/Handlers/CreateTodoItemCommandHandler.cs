using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoService.Application.DTO;
using TodoService.Application.TodoItems.Commands;
using TodoService.Domain.Entities;
using TodoService.Infrastructure.Repository;

namespace TodoService.Application.TodoItems.Handlers
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, TodoItemDTO>
    {
        private readonly IRepository<TodoItem> _repository;

        public CreateTodoItemCommandHandler(IRepository<TodoItem> repository)
        {
            _repository = repository;
        }
        
        public async Task<TodoItemDTO> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
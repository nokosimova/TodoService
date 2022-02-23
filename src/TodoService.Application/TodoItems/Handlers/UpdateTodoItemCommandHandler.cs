using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoService.Application.TodoItems.Commands;
using TodoService.Domain.Entities;
using TodoService.Infrastructure.Repository;

namespace TodoService.Application.TodoItems.Handlers
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly IRepository<TodoItem> _repository;

        public UpdateTodoItemCommandHandler(IRepository<TodoItem> repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
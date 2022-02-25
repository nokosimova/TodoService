using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TodoService.Application.DTO;
using TodoService.Application.TodoItems.Commands;
using TodoService.Domain.Entities;
using TodoService.Infrastructure.Repository;

namespace TodoService.Application.TodoItems.Handlers
{
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly IRepository<TodoItem> _repository;

        public DeleteTodoItemCommandHandler(IRepository<TodoItem> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Item);
            return Unit.Value;
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TodoService.Application.TodoItems.Commands;
using TodoService.Domain.Entities;
using TodoService.Infrastructure.Repository;

namespace TodoService.Application.TodoItems.Handlers
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
    {
        private readonly IRepository<TodoItem> _repository;

        public UpdateTodoItemCommandHandler(IRepository<TodoItem> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            request.Item.Name = request.UpdatedItem.Name;
            request.Item.IsComplete = request.UpdatedItem.IsComplete;
            
            await _repository.UpdateAsync(request.Item); 
            
            return Unit.Value;
        }
    }
}
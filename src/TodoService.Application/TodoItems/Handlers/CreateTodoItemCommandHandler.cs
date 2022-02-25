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
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, TodoItem>
    {
        private readonly IRepository<TodoItem> _repository;
        public CreateTodoItemCommandHandler(IRepository<TodoItem> repository)
        {
            _repository = repository;
        }
        
        public async Task<TodoItem> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.CreateAsync(request.Item);
            return result;
        }
    }
}
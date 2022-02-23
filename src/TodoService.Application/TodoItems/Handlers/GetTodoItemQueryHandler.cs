using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TodoService.Application.DTO;
using TodoService.Application.TodoItems.Commands;
using TodoService.Application.TodoItems.Queries;
using TodoService.Domain.Entities;
using TodoService.Infrastructure.Repository;

namespace TodoService.Application.TodoItems.Handlers
{
    public class GetTodoItemQueryHandler : IRequestHandler<GetTodoItemQuery, TodoItem>
    {
        private readonly IRepository<TodoItem> _repository;
        private readonly IMapper _mapper;

        public GetTodoItemQueryHandler(IRepository<TodoItem> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TodoItem> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(request.Id);
        }
    }
}
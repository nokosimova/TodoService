using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TodoService.Application.DTO;
using TodoService.Application.TodoItems.Queries;
using TodoService.Domain.Entities;
using TodoService.Infrastructure.Repository;

namespace TodoService.Application.TodoItems.Handlers
{
    public class GetAllTodoItemsQueryHandler: IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItem>>
    {
        private readonly IRepository<TodoItem> _repository;

        public GetAllTodoItemsQueryHandler(IRepository<TodoItem> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoItem>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}